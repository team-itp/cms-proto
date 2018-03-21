# 文書管理システム

小規模の会社で文書管理を行う。

## Description

10 〜 20 人規模の会社で紙ベースの文書ファイルを電子化して管理する。
スキャナーで取り込んだファイルを(スキャナーの機能で)一度共有サーバーに
アップロードし、ユーザーにタグをつけてもらい、WordPress にアップロードする。
アップロードした文書は WordPress 上でタグごとに参照ができる。

PC操作にはあまり馴染みのないユーザーを想定し、アップロードの際には専用
クライアントを使用してログイン・タグ付け・複数ファイルアップロードの補助をする。

***DEMO:***

![Demo](https://image-url.gif) (TODO)

## Features

- 複数ファイルのタグ付け・アップロード
- (TODO)表示方法

## Requirement

(TBD)

- Microsoft Azure で実行する (既存アカウントがあるから)
- メジャーなCMSを使用して過度にカスタマイズしない

## Installation

***WordPressの起動***

```
$ git clone https://github.com/team-itp/cms-proto
$ cd server
$ docker-compose
```

## Author

[@chameleonhead](https://twitter.com/chameleonhead)
[@OmosirokiKotoMo](https://twitter.com/OmosirokiKotoMo)
