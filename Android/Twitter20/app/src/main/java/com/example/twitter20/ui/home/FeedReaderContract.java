package com.example.twitter20.ui.home;

import android.provider.BaseColumns;

public final class FeedReaderContract {

    private FeedReaderContract(){

    }

    public static class FeedEntry implements BaseColumns{

        public static final String TABLE_NAME = "tweets";
        public static final String COLUMN_NAME = "name";
        public static final String COLUMN_NICKNAME = "nickname";
        public static final String COLUMN_ACCOUNT = "account";
        public static final String COLUMN_TWEET = "tweet";

         static final String SQL_CREATE_ENTRIES =
                "CREATE TABLE " + FeedEntry.TABLE_NAME + " (" +
                        FeedEntry._ID + " INTEGER PRIMARY KEY," +
                        FeedEntry.COLUMN_NAME + " TEXT," +
                        FeedEntry.COLUMN_NICKNAME + " TEXT," +
                        FeedEntry.COLUMN_ACCOUNT + " TEXT," +
                        FeedEntry.COLUMN_TWEET + " TEXT)";

        static final String SQL_DELETE_ENTRIES =
                "DROP TABLE IF EXISTS " + FeedEntry.TABLE_NAME;

    }
}
