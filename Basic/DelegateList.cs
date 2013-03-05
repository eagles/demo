using System;
using System.Text;

namespace Example.DelegateList
{
    internal sealed class Light
    {
        public string SwitchPosition()
        {
            return "The light is off";
        }
    }

    internal sealed class Fan
    {
        public String Speed()
        {
            throw new InvalidOperationException("The fan broke due to overheating.");
        }
    }

    internal sealed class Speaker
    {
        public String Volume()
        {
            return "The volume is loud";
        }
    }

    public sealed class Program
    {
        // 委托的定义，该委托诵读查询一个组件的状态
        private delegate String GetStatus();

        public static void Main(String[] args)
        {
            // 声明一个委托链
            GetStatus getStatus = null;

            // 构造3个组件，将它们的状态方法添加到委托链中
            getStatus += new GetStatus(new Light().SwitchPosition);
            getStatus += new GetStatus(new Fan().Speed);
            getStatus += new GetStatus(new Speaker().Volume);

            // 显示整理好的状态报告，反映这3个组件的状态
            Console.WriteLine(GetComponentStatusReport(getStatus));
        }

        private static String GetComponentStatusReport(GetStatus status)
        {
            // 如果委托链为空，就不进行任何操作
            if (status == null)
                return null;

            StringBuilder report = new StringBuilder();

            Delegate[] arrayOfDelegates = status.GetInvocationList();

            // 遍历数组中的每一个委托
            foreach (GetStatus getStatus in arrayOfDelegates)
            {
                try
                {
                    report.AppendFormat("{0} {1} {1}", getStatus(), Environment.NewLine);
                }
                catch(InvalidOperationException e)
                {
                    Object component = getStatus.Target;
                    report.AppendFormat("Failed to get status from {1} {2} {0}  Error: {3} {0} {0}",
                        Environment.NewLine, 
                        ((component == null) ? "" : component.GetType() + "."),
                        getStatus.Method.Name,
                        e.Message);
                }
            }

            return report.ToString();
        }
    }
}