package com.example.twitter20.NewTweet;

import android.content.ContentValues;
import android.content.Context;
import android.database.sqlite.SQLiteDatabase;

import com.example.twitter20.DB.DbContract;
import com.example.twitter20.DB.DbHelper;

public class NewTweetPresenter {

    DbHelper dbHelper;
    SQLiteDatabase dbWrite;


    public Boolean AddTweet(String tweetText, int UID, Context context) {
        ContentValues values = new ContentValues();
        values.put(DbContract.TweetEntry.COLUMN_PHOTO, "TEMP\\path\\to\\solve");
        values.put(DbContract.TweetEntry.COLUMN_TWEET, tweetText);
        values.put(DbContract.TweetEntry.COLUMN_USER_ID, UID);
        // Insert the new row, returning the primary key value of the new row
        dbHelper = new DbHelper(context);
        dbWrite = dbHelper.getWritableDatabase();
        long newRowId = dbWrite.insert(DbContract.TweetEntry.TABLE_NAME, null, values);

        return newRowId > 0;
    }


}
