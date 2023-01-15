using System;
using System.Threading;

namespace Hello_Class_stud
{
    //Implement class Morse_matrix derived from String_matrix, which realize IMorse_crypt
    class Morse_matrix : String_matrix, IMorse_crypt
    {
        public const int Size_2 = Alphabet.Size;
        private int offset_key = 0;


        //Implement Morse_matrix constructor with the int parameter for offset
        //Use fd(Alphabet.Dictionary_arr) and sd() methods
        public Morse_matrix()
        {
  
        }
        public Morse_matrix(int offset)
        {
            offset_key = offset;
            fd(Alphabet.Dictionary_arr);
            sd();
         }

        //Implement Morse_matrix constructor with the string [,] Dict_arr and int parameter for offset
        //Use fd(Dict_arr) and sd() methods
        public Morse_matrix(string[,] Dict_arr)
        {
            fd(Dict_arr);
            sd();
        }
        


        private void fd(string[,] Dict_arr)
        {
            for (int ii = 0; ii < Size1; ii++)
                for (int jj = 0; jj < Size_2; jj++)
                    this[ii, jj] = Dict_arr[ii, jj];
        }


        private  void sd()
        {
            int off = Size_2 - offset_key;
            for (int jj = 0; jj < off; jj++)
                this[1, jj] = this[1, jj + offset_key];
            for (int jj = off; jj < Size_2; jj++)
                this[1, jj] = this[1, jj - off];
        }


        //Implement Morse_matrix operator +

        public static Morse_matrix operator +(Morse_matrix Morse_matrix1, Morse_matrix Morse_matrix2)
        {
            Morse_matrix Morse_matrix = new Morse_matrix(0);
            //додавати Morse_matrix1 + Morse_matrix2
            return Morse_matrix;
        }

        //Realize crypt() with string parameter
        //Use indexers
        public string crypt(string word)
        {
            string char_pool = null;
            string[,] alphabet = Alphabet.Dictionary_arr;
            foreach (char c in word)
            {
                for (int i = 0; i < Alphabet.Size; i++)
                {
                    if (alphabet[0, i] == c.ToString())
                    {
                        char_pool += alphabet[1, i];
                    }
                }
            }
            return char_pool;
        }

        //Realize decrypt() with string array parameter
        //Use indexers

        public string decrypt(string[] char_pool)
        {
            string word = null;
            string[,] alphabet = Alphabet.Dictionary_arr;
            string d1, d2;
            int dd1,dd2;

            dd1 = alphabet.GetLength(1);
            dd2 = char_pool.Length;

            for (int i=0; i< char_pool.Length; i++)
            {

                d2 = char_pool[i];
                for (int j = 0; j < alphabet.GetLength(1); j++)
                {
                    d1 = alphabet[1, j];
                   
                    if (String.Equals(alphabet[1, j], char_pool[i]))
                    {
                        word += alphabet[0, j];
                    }
                }
            }
            return word;
        }

        //Implement Res_beep() method with string parameter to beep the string
        public void Res_beep(string charCode)
        {
            foreach (char r in charCode)
            {
                if (r == char.Parse("."))
                {
                    Console.Beep(1000, 250);
                }
                if (r == char.Parse("-"))
                {
                    Console.Beep(1000, 750);
                }
                Thread.Sleep(50);
            }
        }
    }
}

