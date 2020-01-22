package com.example.twitter20.navigation.Home;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.FrameLayout;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import com.example.twitter20.DB.DbContract;
import com.example.twitter20.DB.DbHelper;
import com.example.twitter20.R;
import com.example.twitter20.Model.Tweet;
import com.example.twitter20.Model.User;
import com.example.twitter20.ViewTweet.ViewTweet;

import java.util.List;
import java.util.Random;

public class HomeAdapter extends ArrayAdapter<Tweet> {

    Context mCtx;
    int resource;
    static List<Tweet> tweetList;

    TextView Name;
    TextView NickName;
    DbHelper dbHelper;
    SQLiteDatabase dbRead;
    int UID;
    User u;

    public HomeAdapter(Context mCtx, int resource, List<Tweet> tweetList) {
        super(mCtx, resource, tweetList);
        this.mCtx = mCtx;
        this.resource = resource;
        HomeAdapter.tweetList = tweetList;
    }

    // Random number generator
    static String getRandom() {
        Random r = new Random();
        return String.valueOf(r.nextInt(50));
    }

    @NonNull
    @Override
    public View getView(final int position, @Nullable View convertView, @NonNull ViewGroup parent) {

        convertView = LayoutInflater.from(getContext()).inflate(R.layout.fragment_tweet_list_design, parent, false);


        final SharedPreferences pref = getContext().getSharedPreferences("com.example.twitter20", Context.MODE_PRIVATE);
        UID = pref.getInt("ID", 0);


        dbHelper = new DbHelper(this.getContext());
        dbRead = dbHelper.getReadableDatabase();

        Name = convertView.findViewById(R.id.tweetter_name);
        NickName = convertView.findViewById(R.id.tweeter_nickname);


        Cursor cursor = dbRead.query(
                DbContract.UserEntry.TABLE_NAME,   // The table to query
                new String[]{DbContract.UserEntry.COLUMN_NAME, DbContract.UserEntry.COLUMN_NICKNAME
                        , DbContract.UserEntry.COLUMN_ACCOUNT},
                DbContract.UserEntry._ID + "=?",
                new String[]{String.valueOf(UID)},
                null,
                null,
                null
        );

        if (cursor.getCount() > 0) {
            while (cursor.moveToNext()) {
                u = new User();
                u.Name = cursor.getString(
                        cursor.getColumnIndexOrThrow(DbContract.UserEntry.COLUMN_NAME));
                u.NickName = cursor.getString(
                        cursor.getColumnIndexOrThrow(DbContract.UserEntry.COLUMN_NICKNAME));
                Name.setText(u.Name);
                NickName.setText(u.NickName);
            }
        }
        cursor.close();


        TextView tweet = convertView.findViewById(R.id.tweet_text_content);
        //TextView image = convertView.findViewById(R.id.tweet_shared_image);

        FrameLayout cardView = convertView.findViewById(R.id.cardView);
        TextView likesCount = convertView.findViewById(R.id.likes_count_number);
        TextView retweetCount = convertView.findViewById(R.id.retweets_count_number);
        TextView commentsCount = convertView.findViewById(R.id.comments_count_number);
        TextView shareCount = convertView.findViewById(R.id.shares_count_number);

        Tweet t = tweetList.get(position);
        tweet.setText(t.getTweetText());
        //image.setText(t.getTweetImage());

        cardView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Tweet t = tweetList.get(position);
                Intent i = new Intent(getContext(), ViewTweet.class);
                i.putExtra("TweetText",  t.TweetText);
                i.putExtra("TweetID", t.ID);
                i.putExtra("user_name", u.Name);
                i.putExtra("user_nick", u.NickName);
                getContext().startActivity(i);
            }
        });

        likesCount.setText(getRandom());
        commentsCount.setText(getRandom());
        shareCount.setText(getRandom());
        retweetCount.setText(getRandom());

        return convertView;
    }
}
