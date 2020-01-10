package com.example.twitter20.ui.home;

import android.media.Image;

import java.util.Date;

class Tweet {

    String TweetText;
    String TweetImage;

    int TweetLikeCount;
    int TweetCommentCount;
    int TweetShareCount;

    public Tweet(String tweetText, String tweetImage) {

        TweetText = tweetText;
        TweetImage = tweetImage;
    }

    public Tweet() {

    }

    public String getTweetText() {
        return TweetText;
    }

    public void setTweetText(String tweetText) {
        TweetText = tweetText;
    }

    public String getTweetImage() {
        return TweetImage;
    }

    public void setTweetImage(String tweetImage) {
        TweetImage = tweetImage;
    }
}
