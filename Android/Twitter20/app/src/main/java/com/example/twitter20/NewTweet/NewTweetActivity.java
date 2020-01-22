package com.example.twitter20.NewTweet;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.example.twitter20.R;

public class NewTweetActivity extends AppCompatActivity {

    Button btn;
    int loggedInUserID;
    NewTweetPresenter mNewTweetPresenter = new NewTweetPresenter();
    Context context;
    TextView tweet;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        context = this.getApplicationContext();
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_new_tweet);
        SharedPreferences pref = this.getApplicationContext().getSharedPreferences("com.example.twitter20", 0);
        loggedInUserID = pref.getInt("ID", 0);
        btn = findViewById(R.id.btn_submit_tweet);
        tweet = findViewById(R.id.txt_new_tweet_content);
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String tweetText = tweet.getText().toString();
                if (mNewTweetPresenter.AddTweet(tweetText, loggedInUserID, context)) {
                    Toast.makeText(context, "Tweet Added", Toast.LENGTH_SHORT).show();
                    finish();
                }
            }
        });
    }
}
