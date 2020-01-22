package com.example.twitter20.navigation.Tweet;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.view.View;
import android.widget.ListView;

import com.example.twitter20.DB.DbContract;
import com.example.twitter20.DB.DbHelper;
import com.example.twitter20.R;

import java.util.ArrayList;
import java.util.List;

public class HomePresenter {

    List<Tweet> tweetList;
    DbHelper dbHelper;
    SQLiteDatabase dbRead;
    int UID;
    View view;
    Context context;


    HomePresenter(View view, Context context, int UID) {
        this.view = view;
        this.context = context;
        this.UID = UID;
    }


    void GetTweets() {
        dbHelper = new DbHelper(context);
        dbRead = dbHelper.getReadableDatabase();

        tweetList = new ArrayList<>();
        ListView listView;
        String[] projection = {
                DbContract.TweetEntry._ID,
                DbContract.TweetEntry.COLUMN_USER_ID,
                DbContract.TweetEntry.COLUMN_PHOTO,
                DbContract.TweetEntry.COLUMN_TWEET
        };

        String where = DbContract.TweetEntry.COLUMN_USER_ID;
        String[] whereArgs = new String[]{String.valueOf(UID)};


        Cursor cursor = dbRead.query(
                DbContract.TweetEntry.TABLE_NAME,   // The table to query
                projection,
                where + "=?",
                whereArgs,
                null,
                null,
                null
        );
        while (cursor.moveToNext()) {
            Tweet t = new Tweet();
            t.ID = cursor.getInt(
                    cursor.getColumnIndexOrThrow(DbContract.TweetEntry._ID));
            t.TweetText = cursor.getString(
                    cursor.getColumnIndexOrThrow(DbContract.TweetEntry.COLUMN_TWEET));
            t.TweetImage = cursor.getString(
                    cursor.getColumnIndexOrThrow(DbContract.TweetEntry.COLUMN_PHOTO));

            tweetList.add(t);
        }
        cursor.close();

        listView = view.findViewById(R.id.TweetsList); // TODO fix view

        HomeAdapter HomeAdapter =
                new HomeAdapter(context, R.layout.fragment_tweet_list_design, tweetList);

        listView.setAdapter(HomeAdapter);
    }
}
