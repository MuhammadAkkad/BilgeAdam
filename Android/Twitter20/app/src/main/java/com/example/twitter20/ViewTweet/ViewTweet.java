package com.example.twitter20.ViewTweet;

import android.content.ContentValues;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.example.twitter20.DB.DbContract;
import com.example.twitter20.DB.DbHelper;
import com.example.twitter20.R;
import com.example.twitter20.Model.Comment;
import com.example.twitter20.Comment.CommentAdapter;
import com.example.twitter20.Model.Tweet;
import com.example.twitter20.Model.User;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class ViewTweet extends AppCompatActivity {

    ListView listView;
    TextView Name;
    int TweetID;
    //TextView Account;
    TextView NickName;
    List<Comment> comments;
    List<User> users;
    DbHelper dbHelper;
    SQLiteDatabase dbRead;
    SQLiteDatabase dbWrite;
    int UID;
    Button btnAddComment;

    // Random number generator
    static String getRandom() {
        Random r = new Random();
        return String.valueOf(r.nextInt(50));
    }

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

        btnAddComment = findViewById(R.id.btn_add_comment);
        btnAddComment.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                AddComment(v);
            }
        });

        Intent i = getIntent();
        Tweet t = new Tweet();
        User u = new User();
        TweetID = i.getIntExtra("TweetID", -1);
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
        dbWrite = dbHelper.getWritableDatabase();
        comments = new ArrayList<>();
        users = new ArrayList<>();


        String rawQuery = "SELECT user._id,user.name,user.nickname,comment.comment, comment._id FROM comment " +
                "INNER JOIN mapping  on comment._id = mapping.CID " +
                "inner join tweet on mapping.TID = tweet._id " +
                "inner join user on user._id = mapping.UID " +
                "where tweet._id = " + TweetID;


        Cursor cursor = dbRead.rawQuery(
                rawQuery,
                null
        );
        //Comment c = new Comment();
         while (cursor.moveToNext()) {

            User user = new User();

             user.CID = cursor.getInt(
                    cursor.getColumnIndexOrThrow(DbContract.CommentEntry._ID));
             user.Comment = cursor.getString(
                    cursor.getColumnIndexOrThrow(DbContract.CommentEntry.COLUMN_COMMENT));
            // get comment's user info
            user.Name = cursor.getString(
                    cursor.getColumnIndexOrThrow(DbContract.UserEntry.COLUMN_NAME));
            user.NickName = cursor.getString(
                    cursor.getColumnIndexOrThrow(DbContract.UserEntry.COLUMN_NICKNAME));
            users.add(user);

        }
        cursor.close();

        listView = findViewById(R.id.listComments);
        CommentAdapter itemsAdapter =
                new CommentAdapter(this, R.layout.fragment_comment_list_design, users);
        listView.setAdapter(itemsAdapter);

    }

    void AddComment(View view) {
        TextView commentText = findViewById(R.id.txt_add_comment);
        String commentString = commentText.getText().toString();
        ContentValues values = new ContentValues();
        values.put(DbContract.CommentEntry.COLUMN_COMMENT, commentString);
        // Insert the new row, returning the primary key value of the new row
        long newRowId = dbWrite.insert(DbContract.CommentEntry.TABLE_NAME, null, values);

        if (newRowId > 0) {
            Toast.makeText(this, "Comment Added", Toast.LENGTH_SHORT).show();
            ContentValues val = new ContentValues();
            val.put(DbContract.MappingEntry.COLUMN_CID, newRowId);
            val.put(DbContract.MappingEntry.COLUMN_UID, UID);
            val.put(DbContract.MappingEntry.COLUMN_TID, TweetID);
            val.put(DbContract.MappingEntry.COLUMN_IID, 2);
            long map = dbWrite.insert(DbContract.MappingEntry.TABLE_NAME, null, val);
            if (map > 0)
                Toast.makeText(this, "Mapping Added", Toast.LENGTH_SHORT).show();
            this.finish();
        }
    }
}

