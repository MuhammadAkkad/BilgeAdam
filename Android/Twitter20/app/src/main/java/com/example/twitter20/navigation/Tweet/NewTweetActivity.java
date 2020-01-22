package com.example.twitter20.navigation.Tweet;

import android.content.ContentValues;
import android.content.SharedPreferences;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.example.twitter20.DB.DbContract;
import com.example.twitter20.DB.DbHelper;
import com.example.twitter20.R;

public class NewTweetActivity extends AppCompatActivity {
    int loggendInUserID;
    DbHelper dbHelper;
    SQLiteDatabase dbRead;
    SQLiteDatabase dbWrite;
    Button btn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_new_tweet);
        btn = findViewById(R.id.btn_submit_tweet);
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                AddTweet(v);
            }
        });

        dbHelper = new DbHelper(this);
        dbRead = dbHelper.getReadableDatabase();
        dbWrite = dbHelper.getWritableDatabase();
        SharedPreferences pref = this.getApplicationContext().getSharedPreferences("com.example.twitter20", 0);
        loggendInUserID = pref.getInt("ID", 0);

    }


    public void AddTweet(View view) {
        TextView tweet = findViewById(R.id.txt_new_tweet_content);
        String tweetText = tweet.getText().toString();
        ContentValues values = new ContentValues();
        values.put(DbContract.TweetEntry.COLUMN_PHOTO, "TEMP\\path\\to\\solve");
        values.put(DbContract.TweetEntry.COLUMN_TWEET, tweetText);
        values.put(DbContract.TweetEntry.COLUMN_USER_ID, loggendInUserID);
        // Insert the new row, returning the primary key value of the new row
        long newRowId = dbWrite.insert(DbContract.TweetEntry.TABLE_NAME, null, values);


        if (newRowId > 0) {
            Toast.makeText(this, "Tweet Added", Toast.LENGTH_SHORT).show();
            this.finish();
        }
    }
}
