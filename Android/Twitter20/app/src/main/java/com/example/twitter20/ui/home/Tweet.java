package com.example.twitter20.ui.home;

import android.media.Image;

import java.util.Date;

class Tweet {

    String Name;
    String NickName;
    String Account;
    Date TweetDate;
    String TweetText;
    //Image TweetImage;
    int TweetLikeCount;
    int TweetCommentCount;
    int TweetShareCount;

    public Tweet(String Name, String NickName, String Account, Date tweetDate, String tweetText) {
        this.Name = Name;
        this.NickName = NickName;
        this.Account = Account;
        TweetDate = tweetDate;
        TweetText = tweetText;
        //TweetImage = tweetImage;
    }

    public String getAccount() {
        return Account;
    }

    public void setAccount(String account) {
        Account = account;
    }

    public Tweet() {

    }


    //region Getters

    public String getName() {
        return Name;
    }

    public String getNickName() {
        return NickName;
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

    public void setName(String Name) {
        Name = Name;
    }

    public void setNickName(String NickName) {
        NickName = NickName;
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
