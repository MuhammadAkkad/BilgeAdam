package com.example.twitter20.ui.Tweet;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.widget.Adapter;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

import com.example.twitter20.DbContract;
import com.example.twitter20.DbHelper;
import com.example.twitter20.R;
import com.example.twitter20.ui.Comment.Comment;
import com.example.twitter20.ui.User.User;
import com.google.android.material.navigation.NavigationView;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class ViewTweet  extends AppCompatActivity {

    ListView listView;
    TextView Name;
    int TweetID;
    //TextView Account;
    TextView NickName;
    List<Comment> comments;
    DbHelper dbHelper;
    SQLiteDatabase dbRead;
    int UID;



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
        TweetID = i.getIntExtra("TweetID",-1);
        t.TweetText = i.getStringExtra("TweetText");
        u.Name = i.getStringExtra("user_name");
        u.NickName = i.getStringExtra("user_nick");

        tweet.setText(t.TweetText);
        Name.setText(u.Name);
        NickName.setText(u.NickName);

        comments = new ArrayList<>();

        final SharedPreferences pref = this.getSharedPreferences("com.example.twitter20", Context.MODE_PRIVATE);
        UID = pref.getInt("ID", 0);
        dbHelper = new DbHelper(this);
        dbRead = dbHelper.getReadableDatabase();
        comments = new ArrayList<>();


        String[] projection = {
                DbContract.CommentEntry._ID,
                DbContract.CommentEntry.COLUMN_COMMENT
        };

        String where = DbContract.CommentEntry._ID;
        String[] whereArgs = new String[]{String.valueOf(UID)};


//        comments.add(new Comment("Wow this is awesome man!"));
//        comments.add(new Comment("i disagree dude i dont think is is right"));
//        comments.add(new Comment("thats might be a good point"));
//        comments.add(new Comment("hell yeah"));
//        comments.add(new Comment("Wow this is awesome man!"));
//        comments.add(new Comment("i disagree dude i dont think is is right"));
//        comments.add(new Comment("thats might be a good point"));
//        comments.add(new Comment("hell yeah"));
//        comments.add(new Comment("Wow this is awesome man!"));
//        comments.add(new Comment("i disagree dude i dont think is is right"));
//        comments.add(new Comment("thats might be a good point"));
//        comments.add(new Comment("hell yeah"));

        listView = findViewById(R.id.listComments);
        ArrayAdapter<Comment> itemsAdapter =
                new ArrayAdapter<Comment>(this, android.R.layout.simple_list_item_1, comments);
        listView.setAdapter(itemsAdapter);

    }

    // Random number generator
    static String getRandom() {
        Random r = new Random();
        return String.valueOf(r.nextInt(50));
    }
}

