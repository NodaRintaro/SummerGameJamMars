作業は各自のブランチで自分の名前が書いてあるフォルダでお願いします
プルリク先：Develop

#コーディング規約

・フィールド変数：_camelCase、_hoge、_playerName
・メソッドやクラス、スクリプト名：PascalCase、Hoge、PlayerController
・public変数は、プロパティにする。： private bool _isFlag; public bool IsFlag => _isFlag;
・bool型の変数の先頭：isFlag、canMove、hasItemなど
・[SerializeField]使用時：[Header("ここに変数の説明")]、[SerializeField, Header("ヒットしたかどうか")] private bool _isHit;
・アクセス修飾子：必須
　　例）private float _hoge;、public void HogeMethod(){～};、protected int _hp;
・文字コード：UTF-8
・コミット文の先頭：[add] プレイヤーのHP周りの機能、[fix] ○○のエラー
　　[add] 追加
　　[update] 変更
　　[fix] 修正
　　[remove] 削除
　　[clean] 移動
