package com.example.twitter20.ui.Tweet;

import android.content.Context;
import android.content.SharedPreferences;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import com.example.twitter20.DbContract;
import com.example.twitter20.DbHelper;
import com.example.twitter20.R;
import com.example.twitter20.ui.User.User;

import java.util.List;
import java.util.Random;

public class HomeAdapter extends ArrayAdapter<Tweet> {

    Context mCtx;
    int resource;
    List<Tweet> tweetList;

    TextView Name;
    //TextView Account;
    TextView NickName;
    TextView Date;
    DbHelper dbHelper;
    SQLiteDatabase dbRead;
    int UID;

    public HomeAdapter(Context mCtx, int resource, List<Tweet> tweetList) {
        super(mCtx, resource, tweetList);
        this.mCtx = mCtx;
        this.resource = resource;
        this.tweetList = tweetList;
    }

    // Random number generator
    static String getRandom() {
        Random r = new Random();
        return String.valueOf(r.nextInt(50));
    }

    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        LayoutInflater inflater = LayoutInflater.from(mCtx);
        convertView = LayoutInflater.from(getContext()).inflate(R.layout.fragment_home_design, parent, false);


        final SharedPreferences pref = getContext().getSharedPreferences("com.example.twitter20", Context.MODE_PRIVATE);
        UID = pref.getInt("ID", 0);
        dbHelper = new DbHelper(this.getContext());
        dbRead = dbHelper.getReadableDatabase();

        Name = convertView.findViewById(R.id.tweetter_name);
        //Account = convertView.findViewById(R.id.tweetter_account_name);
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
                User u = new User();
                u.Name = cursor.getString(
                        cursor.getColumnIndexOrThrow(DbContract.UserEntry.COLUMN_NAME));
                u.NickName = cursor.getString(
                        cursor.getColumnIndexOrThrow(DbContract.UserEntry.COLUMN_NICKNAME));
//                u.Account = cursor.getString(
//                        cursor.getColumnIndexOrThrow(DbContract.UserEntry.COLUMN_ACCOUNT));

                Name.setText(u.Name);
                NickName.setText(u.NickName);
                //Account.setText(u.Account);
            }
        }
        cursor.close();


        TextView tweet = convertView.findViewById(R.id.tweet_text_content);
        //TextView image = convertView.findViewById(R.id.tweet_shared_image);

        TextView likesCount = convertView.findViewById(R.id.likes_count_number);
        TextView retweetCount = convertView.findViewById(R.id.retweets_count_number);
        TextView commentsCount = convertView.findViewById(R.id.comments_count_number);
        TextView shareCount = convertView.findViewById(R.id.shares_count_number);

        Tweet t = tweetList.get(position);
        tweet.setText(t.getTweetText());
        //image.setText(t.getTweetImage());

        likesCount.setText(getRandom());
        commentsCount.setText(getRandom());
        shareCount.setText(getRandom());
        retweetCount.setText(getRandom());

        return convertView;
    }
}
