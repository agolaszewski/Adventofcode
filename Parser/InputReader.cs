using System;
using System.Collections.Generic;
using System.IO;

namespace Parser
{
    public class InputReader
    {
        public List<T> Read<T>(string fileName, Func<string, T> parseFn)
        {
            List<T> result = new List<T>();

            using StreamReader file = new StreamReader(fileName);

            string line = string.Empty;
            while ((line = file.ReadLine()) != null)
            {
                result.Add(parseFn(line.Trim()));
            }
            file.Close();

            return result;
        }

        public List<T> ReadMultiLine<T>(string fileName, Func<List<string>, T> parseFn)
        {
            List<T> result = new List<T>();

            using StreamReader file = new StreamReader(fileName);

            List<string> lines = new List<string>();
            string line = string.Empty;
            while ((line = file.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                {
                    result.Add(parseFn(lines));
                    lines = new List<string>();
                }
                else
                {
                    lines.Add(line.Trim());
                }
            }
            file.Close();

            return result;
        }
    }
}