using MethodBoundaryAspect.Fody.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application
{
	public class Logger : OnMethodBoundaryAspect
	{
		private object instance;
		private MethodBase method;
		private object[] args;

		public virtual void Init(object instance, MethodBase method, object[] args)
		{
			this.instance = instance;
			this.method = method;
			this.args = args;
		}
		public override void OnEntry(MethodExecutionArgs args)
		{
			Console.WriteLine($"Init: {args.Method.DeclaringType.FullName}.{args.Method.Name} [{args.Arguments.Length}] params");
			foreach (var item in args.Method.GetParameters())
			{
				Console.WriteLine($"{item.Name}: {args.Arguments[item.Position]}");
			}
		}

		public override void OnExit(MethodExecutionArgs args)
		{
			Console.WriteLine($"Exit: [{args.ReturnValue}]");
		}

		public override void OnException(MethodExecutionArgs args)
		{
			Console.WriteLine($"OnException: {args.Exception.GetType()}: {args.Exception.Message}");
		}
	}
}
