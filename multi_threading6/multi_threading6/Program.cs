using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace multi_threading6 { 
// فئة تمثل العملية التحضيرية للطبق
    public class DishPreparer
{
    private string dishName;

    public DishPreparer(string name)
    {
        dishName = name;
    }

    public void PrepareDish()
    {
        Console.WriteLine($"Preparing {dishName} started.");
        // هنا يتم وضع الخطوات اللازمة لإعداد الطبق
        Thread.Sleep(2000); // توقف لمدة 2 ثانية
        Console.WriteLine($"{dishName} is ready!");
        Console.WriteLine($"Preparing {dishName} completed.");
    }
}

internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cooking started.");

            // إنشاء كائنات المعالجين للأطباق
            DishPreparer pastaPreparer = new DishPreparer("Spaghetti");
            DishPreparer chickenPreparer = new DishPreparer("Roasted Chicken");

            // إنشاء وتشغيل المواضيع الفرعية باستخدام الأطباق المعالجين
            Thread pastaThread = new Thread(pastaPreparer.PrepareDish);
            Thread chickenThread = new Thread(chickenPreparer.PrepareDish);

            pastaThread.Start();
            chickenThread.Start();

            // انتظار انتهاء المواضيع الفرعية
            pastaThread.Join();
            chickenThread.Join();

            Console.WriteLine("Cooking completed.****************************");

            // استخدام بيئة ThreadPool للمواضيع الفرعية
            Console.WriteLine("Cooking with ThreadPool started.");

            // إعداد البيانات اللازمة للأطباق
            object pastaData = "Spaghetti";
            object chickenData = "Roasted Chicken";

            // بدء المواضيع الفرعية باستخدام ThreadPool وتمرير البيانات المناسبة
            ThreadPool.QueueUserWorkItem(new WaitCallback(PrepareDish), pastaData);
            ThreadPool.QueueUserWorkItem(new WaitCallback(PrepareDish), chickenData);

            // انتظار تنفيذ المواضيع الفرعية
            Thread.Sleep(3000); // انتظار لمدة 3 ثوانٍ

            Console.WriteLine("Cooking with ThreadPool completed.");

            //Console.ReadLine();
        }

        // دالة تمثل عملية إعداد الطبق
        static void PrepareDish(object dishData)
        {
            Console.WriteLine("***************************************");
            string dishName = dishData.ToString();
            Console.WriteLine($"Preparing {dishName} started.");
            // هنا يتم وضع الخطوات اللازمة لإعداد الطبق
            Thread.Sleep(2000); // توقف لمدة 2 ثانية
            Console.WriteLine($"{dishName} is ready!");
            Console.WriteLine($"Preparing {dishName} completed.");
        }
    }
}