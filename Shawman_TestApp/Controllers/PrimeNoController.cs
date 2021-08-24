using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shawman_TestApp.Controllers
{
    public class PrimeNoController : Controller
    {
        // GET: PrimeNo
        public ActionResult Index()
        {
            var num = Request["text1"];
            List<int> mylist = new List<int>();

            int iNum;
            if (int.TryParse(num,out iNum))
            {
                mylist = GeneratePrimesNaive(iNum);
            }

            return View(mylist);
        }


        public static List<int> GeneratePrimesNaive(int n)
        {
            List<int> primes = new List<int>();

            for (int i = 0; i <= n; i++)
            {
                int counter = 0;
                for (int j = 2; j <= i / 2; j++)
                {
                    if (i % j == 0)
                    {
                        counter++;
                        break;
                    }
                }

                if (counter == 0 && i != 1)
                {
                    primes.Add(i);
                }
            }

            return primes;
        }
    }
}
