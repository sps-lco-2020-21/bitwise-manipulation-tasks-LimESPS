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
            BIO_Q3();
            Console.ReadKey();
        }
        static int bittoint(string a)
        {
            return Convert.ToInt32(a, 2);
        }
        static string numbit()
        {
            Console.WriteLine("(alternate method to Q21)Enter input: ");
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
                Console.WriteLine($"Number: {input}, Bits/Character: {Denary_to_hex_Q31(input)}");
            else
                Console.WriteLine($"Number: {input}, Bits/Character: {Denary_to_bits_Q31(input,base_)}");
        }
       
        static string Denary_to_bits_Q31(int a,int base_) //does not work when input is 4 and base 2 is 0
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
                powers.Add(Convert.ToInt32(Math.Pow(base_, i)));
                ++i;
            }
            powers.Reverse();
            return powers;
        }
        static string Denary_to_hex_Q31(int a)
        {
            List<int> power_order = base_order(a, 16);
            List<int> hex_val = new List<int>();
            List<string> return_result = new List<string>();
            int number = a;
            foreach(int item in power_order)
            {
                List<int> result = Denary_to_hexvalue(item, number);
                hex_val.Add(result[0]);
                number = result[1];
            }
            Dictionary<int, string> Letter = new Dictionary<int, string>()
            {
                {10,"A"},
                {11,"B"},
                {12,"C"},
                {13,"D"},
                {14,"E"},
                {15,"F"}
            };
            foreach(int item in hex_val)
            {
                if (Letter.TryGetValue(item, out string end))
                    return_result.Add(Letter[item]);
                
                else
                    return_result.Add(item.ToString());
            }
            return string.Join("", return_result);
                
        }
        static List<int> Denary_to_hexvalue(int list, int number)
        {
            return new List<int> { number / list, number % list };
        }
        static void BIO_Q3() //Works!!
        {
            Console.WriteLine("(To find nth term of upside number) Enter number: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Value of {0}th term is {1}",n,obtain_nth_term(n));
        }
        static int obtain_nth_term(int n) //only works for 1 and all even digit numbers, does not work for odd digit numbers
        {
            List<int> upside_down_numbers = new List<int>();
            for(int i = 0; ; ++i)
            {
                
                if (upside_down_numbers.Count() == n)
                    break;
                if (is_upsidedown_number(i))
                {
                    upside_down_numbers.Add(i);
                    
                }
                
                    
            }
            Console.WriteLine(string.Join(",", upside_down_numbers));
            return upside_down_numbers[upside_down_numbers.Count() - 1];
        }
        static bool is_upsidedown_number(int a)
        {
            string number_form = a.ToString();

            List<int> digit = new List<int>(); //digit is int list
            foreach (char item in number_form.ToCharArray())//.split() function does not actually split string
                digit.Add(int.Parse(item.ToString()));
            
            if(digit.Count() % 2 == 1) //odd number of digits
            {
                
                return loop_Q30(digit);
            }
            else //even number of digits
            {
                
                return loop_Q30_evencount(digit);
            }
        }
        static bool loop_Q30(List <int> digit)
        {
            int i = 0;
            while (i < (digit.Count() / 2))
            {
                if (digit[i] + digit[digit.Count() - (1 + i)] != 10)
                {
                   
                    return false;
                }
                
                ++i;
            }
            if (digit[digit.Count() / 2] * 2 != 10)
            {
                
                return false;
            }
                
            else
                return true;
        }
        static bool loop_Q30_evencount(List<int> digit) //works
        {
            int i = 0;
            while (i < digit.Count() / 2)
            {
                if (digit[i] + digit[digit.Count() - (1 + i)] != 10)
                {
                    
                    return false;
                }
                ++i;
            }
            
            return two_digit_exception(digit,false);
        }
        static bool two_digit_exception(List<int> digit, bool a)
        {
            if (digit[digit.Count() / 2] + digit[(digit.Count() / 2) - 1] != 10)
            {
                
                return false;
            }
            else
                return true;


        }
    }
}
