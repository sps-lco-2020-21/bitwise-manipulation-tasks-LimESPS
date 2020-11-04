using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bitwise_manipulation___Ethan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(rightmost_alternate_method(numbit()));

            List<string> bit_examples = new List<string> { "10101", "10001", "000000100000", "0100111" };
            foreach(string item in bit_examples)
            {
                Console.WriteLine($"\r\n\r\nRightmost bit of {item} is {rightmost_Q19(item)}");
                Console.WriteLine($"\r\n3 Rightmost bits of {item} is {rightmost_for3_Q20(item)}");
                Console.WriteLine($"\r\nleftmost bit of {item} is {Leftmost_Q21(item)}");
            }
            Q_31_basechoice();
           
            Console.ReadKey();
        }
        static int bittoint(string a)
        {
            return Convert.ToInt32(a, 2);
        }
        static string numbit()
        {
            Console.WriteLine("Enter input: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"(alternate method) Rightmost bit for your input {n} is:");
            return Convert.ToString(n, 2);
        }
        static char rightmost_alternate_method(string a)
        {
            List<char> bits = a.ToCharArray().ToList(); //doing a.Split('') gives an error, as I just want to split string into individual characters.
            return bits[bits.Count() - 1];
        }
        static int rightmost_Q19(string a)
        {
            return bittoint(a) % 2;
        }
        static string rightmost_for3_Q20(string a)
        {
            
            List<int> values = new List<int> { 4, 2, 1 };
            int number = bittoint(a) % 8;
            return bit_assign(values, number);
            
        }
        static string bit_assign(List<int> values, int number)
        {
            List<string> threebits = new List<string>();
            for (int i = 0; i < values.Count(); ++i)
            {
                List<string> answer = Q20_comparison(values[i], number);
                threebits.Add(answer[0]);
                number = int.Parse(answer[1]);

            }
            return string.Join("", threebits);
        }
        static List<string> Q20_comparison(int list_num, int value)
        {
            List<string> list_r = new List<string>();
            
            if (value == 0)
                return new List<string> { "0", "0" };
            int remainder = value % list_num;
           
            if (value < list_num)
                return new List<string> { "0", remainder.ToString() };
            if (remainder == 0)
                list_r.Add("1");
            else if (remainder > 0)
                list_r.Add("1");
            else
                list_r.Add("0");
            list_r.Add(remainder.ToString());
            return list_r;
        }
        static string Leftmost_Q21(string a)
        {
            int number = bittoint(a);
            int highest_val = Convert.ToInt32(Math.Pow(2, a.Count()-1));
            if (number < highest_val)
                return "0";
            if (number % highest_val >= 0)
                return "1";
            else
                return "0";
        }
        static void Q_31_basechoice()
        {
            Console.WriteLine("Enter base");
            int base_ = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter denary input");
            int input = int.Parse(Console.ReadLine());
            if (base_ == 16)
                Denary_to_hex_Q31(input);
            Console.WriteLine($"Number: {input}, Bits: {Denary_to_bits_Q31(input,base_)}");
        }
       
        static string Denary_to_bits_Q31(int a,int base_)
        {
            
            return bit_assign(base_order(a, base_), a);
        }
        static List<int> base_order(int a, int base_) //returns list of powers of base needed, eg 1,2,4,8,16 (for base 2)
        {
            List<int> powers = new List<int>();
            int i = 0;
            int number = a;
            while (number > Math.Pow(base_, i))
            {
                powers.Add(Convert.ToInt32(Math.Pow(2, i)));
                ++i;
            }
            powers.Reverse();
            return powers;
        }
        static string Denary_to_hex_Q31(int a)
        {
            List<int> power_order = base_order(a, 16);
            List<int> hex_val = new List<int>();
            int number = a;
            foreach(int item in power_order)
            {
                List<int> result = Denary_to_hexvalue(item, number);
                hex_val.Add(result[0]);
                number = result[1];
            }
            Dictionary<int, string> openWith =
                new Dictionary<int, string> {10,"A" ,
                };
            //TODO convert numbers like 15 into F
        }
        static List<int> Denary_to_hexvalue(int list, int number)
        {
            return new List<int> { number / list, number % list };
        }
    }
}
