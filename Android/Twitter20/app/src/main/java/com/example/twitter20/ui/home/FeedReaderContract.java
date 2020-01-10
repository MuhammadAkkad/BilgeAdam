package com.example.twitter20.ui.home;

import android.provider.BaseColumns;

 final class FeedReaderContract {

    private FeedReaderContract() {

    }

    // Tweet Table
     static class TweetEntry implements BaseColumns {

         static final String TABLE_NAME = "tweet";
         static final String COLUMN_TWEET = "tweet";
         static final String COLUMN_PHOTO = "photo";


        static final String SQL_CREATE_TWEET_TABLE =
                "CREATE TABLE " + TweetEntry.TABLE_NAME + " (" +
                        TweetEntry._ID + " INTEGER PRIMARY KEY," +
                        TweetEntry.COLUMN_TWEET + " TEXT," +
                        TweetEntry.COLUMN_PHOTO + " TEXT)";


        static final String SQL_DELETE_TWEET_TABLE =
                "DROP TABLE IF EXISTS " + TweetEntry.TABLE_NAME;
    }

    // User table
     static class UserEntry implements BaseColumns {


         static final String TABLE_NAME = "user";
         static final String COLUMN_NAME = "name";
         static final String COLUMN_NICKNAME = "nickname";
         static final String COLUMN_ACCOUNT = "account";
         static final String COLUMN_PASSWORD = "password";
         static final String COLUMN_PHOTO = "photo";


        static final String SQL_CREATE_USER_TABLE =
                "CREATE TABLE " + UserEntry.TABLE_NAME + " (" +
                        UserEntry._ID + " INTEGER PRIMARY KEY," +
                        UserEntry.COLUMN_NAME + " TEXT," +
                        UserEntry.COLUMN_NICKNAME + " TEXT," +
                        UserEntry.COLUMN_ACCOUNT + " TEXT," +
                        UserEntry.COLUMN_PASSWORD + " TEXT," +
                        UserEntry.COLUMN_PHOTO + " TEXT)";


        static final String SQL_DELETE_USER_TABLE =
                "DROP TABLE IF EXISTS " + UserEntry.TABLE_NAME;

    }
}

