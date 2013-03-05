using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace MyException
{
    [Serializable]
    public abstract class ExceptionArgs
    {
        public virtual String Message
        {
            get 
            {
                return String.Empty;
            }
        }
    }

    [Serializable]
    public sealed class Exception<TExceptionArgs> : Exception, ISerializable
        where TExceptionArgs : ExceptionArgs
    {
        private const String c_args = "Args";   // 用于(反)序列化
        private readonly TExceptionArgs m_args;

        public TExceptionArgs Args { get { return m_args; } }

        public Exception(String message = null, Exception innerException = null)
            : this(null, message, innerException) { }

        public Exception(TExceptionArgs args, String message = null, Exception innerException = null)
            : base(message, innerException)
        {
            m_args = args;
        }

        // 这个构造器用于反序列化；由于类是密封的，所以构造器是私有的。
        // 如果这个类不是密封的，这个构造应该是受保护的。
        [SecurityPermission(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.SerializationFormatter)]
        private Exception(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            m_args = (TExceptionArgs)info.GetValue(c_args, typeof(TExceptionArgs));
        }

        // 这个方法用于序列化; 由于ISerializable接口，所以它是公共的
        [SecurityPermission(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(c_args, m_args);
            base.GetObjectData(info, context);
        }

        public override String Message
        {
            get
            {
                String baseMsg = base.Message;
                return (m_args == null) ? baseMsg : baseMsg + " (" + m_args.Message + ")";
            }
        }

        public override Boolean Equals(Object obj)
        {
            Exception<TExceptionArgs> other = obj as Exception<TExceptionArgs>;
            if (other == null) return false;
            return Object.Equals(m_args, other.m_args) && base.Equals(obj);
        }

        public override int GetHashCode() { return base.GetHashCode(); }
    }

    [Serializable]
    public sealed class DiskFullExceptionArgs : ExceptionArgs
    {
        private readonly String m_diskpath;   // 在构造时设置的字段

        public DiskFullExceptionArgs(String diskpath)
        {
            m_diskpath = diskpath;
        }

        public String DiskPath
        {
            get { return m_diskpath; }
        }

        public override String Message
        {
            get
            {
                return (m_diskpath == null) ? base.Message : "DiskPath=" + m_diskpath;
            }
        }
    }

    public class TestException
    {
        public static void Main(string[] args)
        {
            try 
            {
                throw new Exception<DiskFullExceptionArgs>(
                    new DiskFullExceptionArgs(@"C:\"), "The disk is full");
            }
            catch (Exception<DiskFullExceptionArgs> e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}