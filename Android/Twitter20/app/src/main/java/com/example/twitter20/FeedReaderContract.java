package com.example.twitter20;

import android.provider.BaseColumns;

public final class FeedReaderContract {

    private FeedReaderContract() {

    }

    // Tweet Table
    public static class TweetEntry implements BaseColumns {

        public static final String TABLE_NAME = "tweet";
        public static final String COLUMN_TWEET = "tweet";
        public static final String COLUMN_PHOTO = "photo";


        public static final String SQL_CREATE_TWEET_TABLE =
                "CREATE TABLE " + TweetEntry.TABLE_NAME + " (" +
                        TweetEntry._ID + " INTEGER PRIMARY KEY," +
                        TweetEntry.COLUMN_TWEET + " TEXT," +
                        TweetEntry.COLUMN_PHOTO + " TEXT)";


        public static final String SQL_DELETE_TWEET_TABLE =
                "DROP TABLE IF EXISTS " + TweetEntry.TABLE_NAME;
    }

    // User table
    public static class UserEntry implements BaseColumns {


        public static final String TABLE_NAME = "user";
        public static final String COLUMN_NAME = "name";
        public static final String COLUMN_NICKNAME = "nickname";
        public static final String COLUMN_ACCOUNT = "account";
        public static final String COLUMN_PASSWORD = "password";
        //static final String COLUMN_PHOTO = "photo";


        public static final String SQL_CREATE_USER_TABLE =
                "CREATE TABLE " + UserEntry.TABLE_NAME + " (" +
                        UserEntry._ID + " INTEGER PRIMARY KEY," +
                        UserEntry.COLUMN_NAME + " TEXT," +
                        UserEntry.COLUMN_NICKNAME + " TEXT," +
                        UserEntry.COLUMN_ACCOUNT + " TEXT," +
                        UserEntry.COLUMN_PASSWORD + " TEXT)";


        public static final String SQL_DELETE_USER_TABLE =
                "DROP TABLE IF EXISTS " + UserEntry.TABLE_NAME;

    }
}

