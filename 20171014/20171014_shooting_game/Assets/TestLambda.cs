using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class TestLambda : MonoBehaviour {

    IEnumerable<int> scores = Enumerable.Range(1, 10);

    void Start () {

        // -------------------------------------------
        // ラムダ式
        // -------------------------------------------

        // 戻り値あり
        Func<int, int> mul = x => x * x;
        // Debug.Log("[Func] mul: " + mul(5));

        // 戻り値なし
        Action<int, int> sum = (x, y) => {
            int t = x + y;
            // Debug.Log("[Action] sum: " + t);
        };
        sum(2, 3);

        // デリゲート
        Action<int, int> delegateSum = Sum;
        delegateSum(2,3);


        // -------------------------------------------
        // LINQ
        // -------------------------------------------

        var oddNums = scores
            .Where(score => score % 2 != 0)
            .OrderByDescending(score => score)
            .Take(3);

        // oddNums.ToList().ForEach(num => Debug.Log("上位3つの奇数 => " + num));

        var maxOddNum1 = scores
            .Last(score => score % 2 != 0);

        // Debug.Log("[pattern1]最大の奇数 => " + maxOddNum1);

        var maxOddNum2 = scores
            .Where(score => score % 2 != 0)
            .Max();

        // Debug.Log("[pattern2]最大の奇数 => " + maxOddNum2);

        var filteredNums1 = scores
            .Where((score, index) => index != 0 && index != scores.Count() - 1)
            .Select(score => (float)score / 10);

        // filteredNums1.ToList().ForEach(num => Debug.Log("[pattern1]最初と最後を除く数を10で割る => " + num));

        var filteredNums2 = scores
            .Skip(1)
            .Reverse()
            .Skip(1)
            .Reverse()
            .Select(score => (float)score / 10);

        // filteredNums2.ToList().ForEach(num => Debug.Log("[pattern2]最初と最後を除く数を10で割る => " + num));

    }

    void Sum(int x, int y) {
        int t = x + y;
        // Debug.Log("[Delegate] sum: " + t);
    }

}
