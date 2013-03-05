using System;
using System.Collections.Generic;
using System.Reflection;

public class Boy
{
    public int BoyId { get; set; }
    public string BoyName { get; set; }
}

public class Girl
{
    public int GirlId { get; set; }  
    public string GirlName { get; set; }
}

class Program
{
    static IDictionary<object, object> GetList<T>()  where T : class
    //static IDictionary<object, object> GetList<T>()  where T : Boy  泛型约束，调用时只能传递Boy类型变量
    {
        Type modelType = typeof(T);
        //创建T对象
        T model = (T)Activator.CreateInstance(modelType);
        //T model = Activator.CreateInstance<T>();
        Type t = model.GetType();
        //获取T对象的所有属性
        PropertyInfo[] props = t.GetProperties();
        //将属性名称作为key，属性值作为value
        Dictionary<object, object> dict = new Dictionary<object, object>();
        foreach (PropertyInfo prop in props)
        {
            //获取属性的名称
            string propName = prop.Name;

            //为model对象的pro属性设置值
            //如果此属性类型是int就赋值10
            if (prop.PropertyType==typeof(Int32))
            {   //在实际开发中 一般用 DataRow获取数据库相应的字段值如 dr[propName]
                prop.SetValue(model, 10, null);
            }
            else //如果此属性类型 不是 int就统一赋值"aaa"
            {
                prop.SetValue(model, "aaa", null);
            }
            //获取model中是属性值
            object propValue=prop.GetValue(model, null);
            dict.Add(propName,propValue.ToString());
        }
        return dict;
    }

    static void Main(string[] args)
    {
        foreach (var item in GetList<Boy>())
        {
            Console.WriteLine(item.Key + ":" + item.Value);
        }
        Console.WriteLine("success");
        Console.ReadKey();
    }
}