package com.example.twitter20.ui.Tweet;

import android.content.Context;
import android.content.SharedPreferences;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProviders;

import com.example.twitter20.DbContract;
import com.example.twitter20.DbHelper;
import com.example.twitter20.R;

import java.util.ArrayList;
import java.util.List;

public class HomeFragment extends Fragment {

    List<Tweet> tweetList;
    String ID;
    DbHelper dbHelper;
    SQLiteDatabase dbRead;
    int UID;
    private HomeViewModel homeViewModel;

    @Nullable
    @Override
    public View getView() {
        return super.getView();
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        final SharedPreferences pref = this.getActivity().getSharedPreferences("com.example.twitter20", Context.MODE_PRIVATE);
        UID = pref.getInt("ID", 0);
        dbHelper = new DbHelper(this.getContext());
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
                new HomeAdapter(this.getContext(), R.layout.fragment_tweet_list_design, tweetList);

        listView.setAdapter(HomeAdapter);
    }

    public View onCreateView(@NonNull LayoutInflater inflater, final ViewGroup container, Bundle savedInstanceState) {
        homeViewModel =
                ViewModelProviders.of(this).get(HomeViewModel.class);
        View root = inflater.inflate(R.layout.fragment_home, container, false);

        return root;
    }
}