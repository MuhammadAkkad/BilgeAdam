package com.example.twitter20.ui.Tweet;

import android.content.Intent;
import android.os.Bundle;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

import com.example.twitter20.R;
import com.example.twitter20.ui.User.User;
import com.google.android.material.navigation.NavigationView;

import java.util.Random;

public class ViewTweet  extends AppCompatActivity {

    TextView Name;
    //TextView Account;
    TextView NickName;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_view_tweet);
        Name = findViewById(R.id.tweetter_name);
        NickName = findViewById(R.id.tweeter_nickname);
        TextView tweet = findViewById(R.id.tweet_text_content);
        TextView likesCount = findViewById(R.id.likes_count_number);
        TextView retweetCount = findViewById(R.id.retweets_count_number);
        TextView commentsCount = findViewById(R.id.comments_count_number);
        TextView shareCount = findViewById(R.id.shares_count_number);
        likesCount.setText(getRandom());
        commentsCount.setText(getRandom());
        shareCount.setText(getRandom());
        retweetCount.setText(getRandom());

        Intent i = getIntent();
        Tweet t = new Tweet();
        User u = new User();
        t.TweetText = i.getStringExtra("TweetText");
        u.Name = i.getStringExtra("user_name");
        u.NickName = i.getStringExtra("user_nick");

        tweet.setText(t.TweetText);
        Name.setText(u.Name);
        NickName.setText(u.NickName);

    }

    // Random number generator
    static String getRandom() {
        Random r = new Random();
        return String.valueOf(r.nextInt(50));
    }
}

