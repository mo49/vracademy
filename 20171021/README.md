## Singleton

- 現在ScoreManagerで管理しているスコアを新規でEventManagerクラスを作成。シングルトン化し、そこでスコアを管理。
UIテキストや敵を倒したときのスコア表示・加算処理をSingletonの呼び出しに置き換えてみよう。

EventManager.cs
https://github.com/mo49/vracademy/blob/master/20171014/20171014_shooting_game/Assets/_Complete-Game/Scripts/Managers/EventManager.cs

ScoreManager.cs
https://github.com/mo49/vracademy/blob/master/20171014/20171014_shooting_game/Assets/_Complete-Game/Scripts/Managers/ScoreManager.cs

## Lambda・LINQ

- 配列の最初と最後の要素は無視して残りの要素を１０で割った数をコンソールに出力してみよう。

https://github.com/mo49/vracademy/blob/master/20171014/20171014_shooting_game/Assets/TestLambda.cs

## Coroutine

- プレイヤーが倒れるアニメーションが終了したら画面が暗転してゲームオーバーのロゴが出るようにしたい。

GameOverManager.cs
https://github.com/mo49/vracademy/blob/master/20171014/20171014_shooting_game/Assets/_Complete-Game/Scripts/Managers/GameOverManager.cs

## Action

- Survival Shooterを実行中に”Esc”キーを押すとメニュー画面が表示されます。
今回はそれを新たにInputManagerクラスを作成し、そこで入力の検知をおこない、メニュー画面表示の処理をデリゲートしてみましょう。

委譲先
InputManager.cs
https://github.com/mo49/vracademy/blob/master/20171014/20171014_shooting_game/Assets/_Complete-Game/Scripts/Managers/InputManager.cs

委譲元
PauseManager.cs
https://github.com/mo49/vracademy/blob/master/20171014/20171014_shooting_game/Assets/_Complete-Game/Scripts/Managers/PauseManager.cs

