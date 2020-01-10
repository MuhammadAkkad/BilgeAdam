package com.example.twitter20.ui.home;

import androidx.appcompat.app.AppCompatActivity;

import android.content.ContentValues;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.twitter20.MainActivity;
import com.example.twitter20.R;

import java.util.ArrayList;
import java.util.List;

public class NewTweetActivity extends AppCompatActivity {
    FeedReaderDbHelper dbHelper;
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

        dbHelper = new FeedReaderDbHelper(this);
        dbWrite = dbHelper.getWritableDatabase();

    }
    public void AddTweet(View view){
        TextView tweet = findViewById(R.id.txt_new_tweet_content);
        String tweetText = tweet.getText().toString();
        ContentValues values = new ContentValues();
        values.put(FeedReaderContract.TweetEntry.COLUMN_PHOTO, "TEMP\\path\\to\\solve");
        values.put(FeedReaderContract.TweetEntry.COLUMN_TWEET,tweetText);
        // Insert the new row, returning the primary key value of the new row
        long newRowId = dbWrite.insert(FeedReaderContract.TweetEntry.TABLE_NAME, null, values);
        Toast.makeText(this, "Tweet Added", Toast.LENGTH_SHORT).show();
        if(newRowId > 0){
        this.finish();
        }
    }
}
