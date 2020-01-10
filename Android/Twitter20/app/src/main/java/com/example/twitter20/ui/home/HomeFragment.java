package com.example.twitter20.ui.home;

import android.content.ContentValues;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import androidx.annotation.Nullable;
import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProviders;

import com.example.twitter20.R;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Random;

public class HomeFragment extends Fragment {

    List<Tweet> tweetList = new ArrayList<>();
    ListView listView;

    private HomeViewModel homeViewModel;


    @Nullable
    @Override
    public View getView() {
        return super.getView();
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

       //tweetList = new ArrayList<>(); // TODO add fake tweets below
       //tweetList.add(new Tweet("Muhammad", "Akkad", new Date(1900, 1, 1), "this is my very powsdferful twedfthet because i sfgdfhdfcauion and why not to tweet everyday about shit?"));
       //tweetList.add(new Tweet("Atilat", "Ati", new Date(1900, 1, 1), "this is mygfhj very powerfsdgul tweet bechoerdfhdfghause i can and why unot to tweet everyday awetwrybout shit?"));
       //tweetList.add(new Tweet("Orkun", "Cacik", new Date(1900, 1, 1), "thiswwertert is my very powerful twhgheet becauiouse i can anyuud why not to wytweet everyday about shit?"));
       //tweetList.add(new Tweet("Simge", "SGS", new Date(1900, 1, 1), "this is my vgdrery powerfulsdg twedfghdfghet because i can and why not to tweet eiyveryday aribout shit?"));
       //tweetList.add(new Tweet("Beyza", "amin", new Date(1900, 1, 1), "this ius my very powerfulj tweet because ihdfhtuio can and gfwhyu not tkodfgh tweet everyday about shit?"));
       //tweetList.add(new Tweet("Guney", "Konya", new Date(1900, 1, 1), "this ityus my very powerful tweet because i can and why not to tweetklhjkjkl everyday about shit?"));
       //tweetList.add(new Tweet("Emre", "Kutahya", new Date(1900, 1, 1), "this iwetrs asdfmy very posdfgwerful tgdfweet because i cyutyan and wfghhy not to tweioet everyday about shit?"));
       //tweetList.add(new Tweet("Dilara", "Selfi", new Date(1900, 1, 1), "this is my very powerful tweettyer becahuse idfg catrun and why not to tweet everyday about shit?"));
       //tweetList.add(new Tweet("Serhat", "Adam", new Date(1900, 1, 1), "thisqer is my very poweraful tweet because i can and why not to twdfghgeet everyday abyuioyuout shit?"));
       //tweetList.add(new Tweet("Baris", "Baris", new Date(1900, 1, 1), "this ierws my very powerful tweet becausaqeretyi i caytn and why not to tweet everydayi about shit?"));
       //tweetList.add(new Tweet("Muhammad", "", new Date(1900, 1, 1), "this is my vetry powerful tweet because i can and why not to tweet awerteveryday about shit?"));



        FeedReaderDbHelper dbHelper = new FeedReaderDbHelper(getContext());
        // Gets the data repository in write mode
        SQLiteDatabase dbR = dbHelper.getWritableDatabase();

        // Create a new map of values, where column names are the keys
        ContentValues values = new ContentValues();
        values.put(FeedReaderContract.FeedEntry.COLUMN_NAME, "Muhammad");
        values.put(FeedReaderContract.FeedEntry.COLUMN_NICKNAME, "Akkado");
        values.put(FeedReaderContract.FeedEntry.COLUMN_ACCOUNT, "@muhammad");
        values.put(FeedReaderContract.FeedEntry.COLUMN_TWEET, "this is my powerfull life changing tweet of today please avoid getting killed today and thanks.");

        // Insert the new row, returning the primary key value of the new row
        long newRowId = dbR.insert(FeedReaderContract.FeedEntry.TABLE_NAME, null, values);

        SQLiteDatabase db = dbHelper.getReadableDatabase();

        // Define a projection that specifies which columns from the database
        // you will actually use after this query.
        String[] projection = {
                FeedReaderContract.FeedEntry.COLUMN_NAME,
                FeedReaderContract.FeedEntry.COLUMN_NICKNAME,
                FeedReaderContract.FeedEntry.COLUMN_ACCOUNT,
                FeedReaderContract.FeedEntry.COLUMN_TWEET
        };

        // Filter results WHERE "title" = 'My Title'
        //String selection = FeedReaderContract.FeedEntry.COLUMN_NAME_TITLE + " = ?";
        //String[] selectionArgs = {"Muhammad"};

        // How you want the results sorted in the resulting Cursor
        String sortOrder =
                FeedReaderContract.FeedEntry.COLUMN_NAME + " DESC";

        Cursor cursor = db.query(
                FeedReaderContract.FeedEntry.TABLE_NAME,   // The table to query
                projection,             // The array of columns to return (pass null to get all)
                null,              // The columns for the WHERE clause
                null,          // The values for the WHERE clause
                null,                   // don't group the rows
                null,                   // don't filter by row groups
                sortOrder               // The sort order
        );
        while (cursor.moveToNext()) {
            Tweet t = new Tweet();
            t.Name = cursor.getString(
                    cursor.getColumnIndexOrThrow(FeedReaderContract.FeedEntry.COLUMN_NAME));
            t.NickName = cursor.getString(
                    cursor.getColumnIndexOrThrow(FeedReaderContract.FeedEntry.COLUMN_NICKNAME));
            t.Account = cursor.getString(
                    cursor.getColumnIndexOrThrow(FeedReaderContract.FeedEntry.COLUMN_ACCOUNT));
            t.TweetText = cursor.getString(
                    cursor.getColumnIndexOrThrow(FeedReaderContract.FeedEntry.COLUMN_TWEET));
            tweetList.add(t);
        }
        cursor.close();

        listView = (ListView) view.findViewById(R.id.TweetsList); // TODO fix view

        HomeAdapter HomeAdapter =
                new HomeAdapter(this.getContext(), R.layout.fragment_home_design, tweetList);

        listView.setAdapter(HomeAdapter);
    }

    public View onCreateView(@NonNull LayoutInflater inflater,
                             final ViewGroup container, Bundle savedInstanceState) {
        homeViewModel =
                ViewModelProviders.of(this).get(HomeViewModel.class);
        View root = inflater.inflate(R.layout.fragment_home, container, false);

        return root;
    }
}