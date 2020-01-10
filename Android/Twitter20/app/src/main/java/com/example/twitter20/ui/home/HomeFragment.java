package com.example.twitter20.ui.home;

import android.content.ContentValues;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;

import androidx.annotation.Nullable;
import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProviders;

import com.example.twitter20.R;

import java.io.File;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.List;

public class HomeFragment extends Fragment {

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

        FeedReaderDbHelper dbHelper = new FeedReaderDbHelper(this.getContext());
        SQLiteDatabase dbRead = dbHelper.getReadableDatabase();
            List<Tweet> tweetList = new ArrayList<>();
            ListView listView;
        String[] projection = {
                FeedReaderContract.TweetEntry.COLUMN_PHOTO,
                FeedReaderContract.TweetEntry.COLUMN_TWEET
        };

        String sortOrder =
                FeedReaderContract.TweetEntry.COLUMN_TWEET + " DESC";

        Cursor cursor = dbRead.query(
                FeedReaderContract.TweetEntry.TABLE_NAME,   // The table to query
                projection,
                null,
                null,
                null,
                null,
                null
        );
        while (cursor.moveToNext()) {
            Tweet t = new Tweet();
            t.TweetText = cursor.getString(
                    cursor.getColumnIndexOrThrow(FeedReaderContract.TweetEntry.COLUMN_TWEET));
            t.TweetImage = cursor.getString(
                    cursor.getColumnIndexOrThrow(FeedReaderContract.TweetEntry.COLUMN_PHOTO));

            tweetList.add(t);
        }
        cursor.close();

        listView = (ListView) view.findViewById(R.id.TweetsList); // TODO fix view

        HomeAdapter HomeAdapter =
                new HomeAdapter(this.getContext(), R.layout.fragment_home_design, tweetList);

        listView.setAdapter(HomeAdapter);


    }

    public View onCreateView(@NonNull LayoutInflater inflater, final ViewGroup container, Bundle savedInstanceState) {
        homeViewModel =
                ViewModelProviders.of(this).get(HomeViewModel.class);
        View root = inflater.inflate(R.layout.fragment_home, container, false);

        return root;
    }
}