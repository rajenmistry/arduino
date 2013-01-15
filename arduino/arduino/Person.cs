using System;

namespace arduino
{
	public class Person
	{
	public string name{get;set;}
		public int age{get;set;}
		public Person (String name, int age)
		{
			
			this.name=name;
			this.age=age;
		}
public void DisplayName()
{

			Console.WriteLine("this is {0} and he is {1}",name,age);
			
		}
	
	}
	
	
	
	
	
	
}

