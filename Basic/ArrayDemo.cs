using System;

namespace Example.Array
{
    public class ArrayDemo
    {
        public static void Main()
        {
            Int32[] myIntegers;    //Delcare an int array, in this stage, myIntegers = null
            myIntegers = new Int32[100];   // Create an 100 size array
            
            String[] myStrings = new String[] {"Eason", "Wu"};  //数组初始化器或叫数组初始值列表
            
            var names = new[] {"Eason", "Wu", null};  //利用C#的隐式类型的局部变量和隐式类型的数组
            
    }
}