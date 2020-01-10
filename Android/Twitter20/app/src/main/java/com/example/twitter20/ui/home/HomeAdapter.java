package com.example.twitter20.ui.home;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;

import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import com.example.twitter20.R;

import java.util.List;
import java.util.Random;

public class HomeAdapter extends ArrayAdapter<Tweet> {

    Context mCtx;
    int resource;
    List<Tweet> tweetList;

    public HomeAdapter(Context mCtx, int resource, List<Tweet> tweetList) {
        super(mCtx, resource, tweetList);
        this.mCtx = mCtx;
        this.resource = resource;
        this.tweetList = tweetList;
    }

    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        LayoutInflater inflater = LayoutInflater.from(mCtx);

        convertView = LayoutInflater.from(getContext()).inflate(R.layout.fragment_home_design, parent, false);


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

    // Random number generator
    static String getRandom() {
        Random r = new Random();
        return String.valueOf(r.nextInt(50));
    }
}
