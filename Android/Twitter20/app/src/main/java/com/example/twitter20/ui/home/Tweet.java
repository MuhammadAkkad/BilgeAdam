package com.example.twitter20.ui.home;

import android.media.Image;

import java.util.Date;

class Tweet {

    String TweeterName;
    String TweeterNickName;
    Date TweetDate;
    String TweetText;
    //Image TweetImage;
    int TweetLikeCount;
    int TweetCommentCount;
    int TweetShareCount;

    public Tweet(String tweeterName, String tweeterNickName, Date tweetDate, String tweetText) {
        TweeterName = tweeterName;
        TweeterNickName = tweeterNickName;
        TweetDate = tweetDate;
        TweetText = tweetText;
        //TweetImage = tweetImage;
    }

    //region Getters

    public String getTweeterName() {
        return TweeterName;
    }

    public String getTweeterNickName() {
        return TweeterNickName;
    }

    public Date getTweetDate() {
        return TweetDate;
    }

    public String getTweetText() {
        return TweetText;
    }

//    public Image getTweetImage() {
//        return TweetImage;
//    }

    public int getTweetLikeCount() {
        return TweetLikeCount;
    }

    public int getTweetCommentCount() {
        return TweetCommentCount;
    }

    public int getTweetShareCount() {
        return TweetShareCount;
    }

    //endregion Getters

    //region Setters

    public void setTweeterName(String tweeterName) {
        TweeterName = tweeterName;
    }

    public void setTweeterNickName(String tweeterNickName) {
        TweeterNickName = tweeterNickName;
    }

    public void setTweetDate(Date tweetDate) {
        TweetDate = tweetDate;
    }

    public void setTweetText(String tweetText) {
        TweetText = tweetText;
    }

//    public void setTweetImage(Image tweetImage) {
//        TweetImage = tweetImage;
//    }

    public void setTweetLikeCount(int tweetLikeCount) {
        TweetLikeCount = tweetLikeCount;
    }

    public void setTweetCommentCount(int tweetCommentCount) {
        TweetCommentCount = tweetCommentCount;
    }

    public void setTweetShareCount(int tweetShareCount) {
        TweetShareCount = tweetShareCount;
    }

    //endregion

}
