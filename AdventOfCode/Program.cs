﻿using AdventOfCode.Year2021;

namespace AdventOfCode
{
    static class Program
    {
        static void Main()
        {
            // new Year2015Executor().Execute();
            // new Year2016Executor().Execute();
            // new Year2017Executor().Execute();
            // new Year2018Executor().Execute();
            // new Year2019Executor().Execute();
            // new Year2020Executor().Execute();

            for (var i = 0; i < 2; i++)
            {
                new Year2021Executor().Execute();
            }
        }
    }
}