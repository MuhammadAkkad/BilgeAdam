package com.example.twitter20;

import android.provider.BaseColumns;


public final class DbContract {

    private DbContract() {
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


    // Interaction table
    public static class InteractionEntry implements BaseColumns {

        public static final String TABLE_NAME = "interaction";
        public static final String COLUMN_INTERACT = "interact";


        public static final String SQL_CREATE_INTERACTION_TABLE =
                "CREATE TABLE " + InteractionEntry.TABLE_NAME + " (" +
                        InteractionEntry._ID + " INTEGER PRIMARY KEY," +
                        InteractionEntry.COLUMN_INTERACT + " TEXT)";

        public static final String SQL_DELETE_INTERACTION_TABLE =
                "DROP TABLE IF EXISTS " + UserEntry.TABLE_NAME;
    }


    // Mapping table
    public static class MappingEntry implements BaseColumns {

        public static final String TABLE_NAME = "mapping";


        public static final String SQL_CREATE_MAPPING_TABLE =
                "CREATE TABLE " + MappingEntry.TABLE_NAME + " (UID INTEGER, TID INTEGER, RTID INTEGER," +
                        " CONTENT TEXT, FOREIGN KEY(UID) REFERENCES user(_ID)," +
                        " FOREIGN KEY(TID) REFERENCES tweet(_ID)," +
                        " FOREIGN KEY(RTID) REFERENCES interaction(_ID))";

        public static final String SQL_DELETE_MAPPING_TABLE =
                "DROP TABLE IF EXISTS " + UserEntry.TABLE_NAME;
    }


}

