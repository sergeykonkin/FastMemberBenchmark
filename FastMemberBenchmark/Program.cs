using System;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using FastMember;

namespace FastMemberBenchmark
{
    public class FastMemberVsPropertyInfo
    {
        private MyClass getInput;
        private string setInput;
        private PropertyInfo prop;
        private TypeAccessor accessor;

        [GlobalSetup]
        public void Setup()
        {
            var random = new Random(42);

            var data = new byte[100];
            random.NextBytes(data);
            getInput = new MyClass
            {
                Data = Convert.ToBase64String(data)
            };

            data = new byte[100];
            random.NextBytes(data);
            setInput = Convert.ToBase64String(data);

            var type = typeof(MyClass);
            prop = type.GetProperty("Data");

            accessor = TypeAccessor.Create(type);

        }

        [Benchmark]
        public object Get_PropertyInfo() => prop.GetValue(getInput);

        [Benchmark]
        public object Get_FastMember() => accessor[getInput, "Data"];

        [Benchmark]
        public object Set_PropertyInfo()
        {
            var obj = new MyClass();
            prop.SetValue(obj, setInput);
            return obj.Data;
        }

        [Benchmark]
        public object Set_FastMember()
        {
            var obj = new MyClass();
            accessor[getInput, "Data"] = setInput;
            return obj.Data;
        }
    }

    public class MyClass
    {
        public string Data { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<FastMemberVsPropertyInfo>();
        }
    }
}
