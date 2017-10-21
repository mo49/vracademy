using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/*
 LINQを使って配列の中から奇数の値のみコンソールに出力するプログラムを書いてみよう。
 */

public class TestLambda : MonoBehaviour {

    IEnumerable<int> scores = Enumerable.Range(1, 10);

    void Start () {
        var oddNums = scores
            .Where(score => score % 2 != 0)
            .OrderByDescending(score => score)
            .Take(3);

        oddNums.ToList().ForEach(num => Debug.Log("[top3]奇数 => " + num));

        var filteredNums1 = scores
            .Where((score, index) => index != 0 && index != scores.Count() - 1)
            .Select(score => (float)score / 10);

        filteredNums1.ToList().ForEach(num => Debug.Log("[pattern1]最初と最後を除く数を10で割る => " + num));

        var filteredNums2 = scores
            .Skip(1)
            .Reverse()
            .Skip(1)
            .Reverse()
            .Select(score => (float)score / 10);

        filteredNums2.ToList().ForEach(num => Debug.Log("[pattern2]最初と最後を除く数を10で割る => " + num));

    }

}
