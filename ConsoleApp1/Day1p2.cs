using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

int BufferSize = 128;

using (var fileStream = File.OpenRead("../../../input.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
{
    List<int> leftList = new List<int>();
    List<int> rightList = new List<int>();

    string line;
    while ((line = streamReader.ReadLine()) != null)
    {
        string[] row = line.Split("   ", StringSplitOptions.RemoveEmptyEntries);

        if (row.Length >= 2)
        {
            leftList.Add(int.Parse(row[0]));
            rightList.Add(int.Parse(row[1]));
        }
    }

    Dictionary<int, int> rightCount = new Dictionary<int, int>();

    foreach (var num in rightList)
    {
        if (rightCount.ContainsKey(num))
        {
            rightCount[num]++;
        }
        else
        {
            rightCount[num] = 1;
        }
    }

    int similarityScore = 0;

    foreach (var num in leftList)
    {
        if (rightCount.ContainsKey(num))
        {
            similarityScore += num * rightCount[num];
        }
    }

    Console.WriteLine(similarityScore);
}
