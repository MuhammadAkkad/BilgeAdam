package com.example.twitter20;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import static com.example.twitter20.FeedReaderContract.TweetEntry.SQL_CREATE_TWEET_TABLE;
import static com.example.twitter20.FeedReaderContract.TweetEntry.SQL_DELETE_TWEET_TABLE;
import static com.example.twitter20.FeedReaderContract.UserEntry.SQL_CREATE_USER_TABLE;
import static com.example.twitter20.FeedReaderContract.UserEntry.SQL_DELETE_USER_TABLE;


public class FeedReaderDbHelper extends SQLiteOpenHelper {
    // If you change the database schema, you must increment the database version.
    public static final int DATABASE_VERSION = 2;
    public static final String DATABASE_NAME = "Twitter.dbRead";

    public FeedReaderDbHelper(Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }
    public void onCreate(SQLiteDatabase db) {
        db.execSQL(SQL_CREATE_TWEET_TABLE);
        db.execSQL(SQL_CREATE_USER_TABLE);
    }
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        // This database is only a cache for online data, so its upgrade policy is
        // to simply to discard the data and start over
        db.execSQL(SQL_DELETE_TWEET_TABLE);
        db.execSQL(SQL_DELETE_USER_TABLE);
        onCreate(db);
    }
    public void onDowngrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        onUpgrade(db, oldVersion, newVersion);
    }
}
