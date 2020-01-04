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

        TextView tweeterName = convertView.findViewById(R.id.tweetter_name);
        TextView tweeterNickName = convertView.findViewById(R.id.tweetter_name); //TODO add nickName
        TextView tweetTxt = convertView.findViewById(R.id.tweet_text_content);
        //ImageView imageView = convertView.findViewById(R.id.tweet_shared_image); // TODO fix image

        TextView likesCount = convertView.findViewById(R.id.likes_count_number);
        TextView commentsCount = convertView.findViewById(R.id.comments_count_number);
        TextView shareCount = convertView.findViewById(R.id.shares_count_number);

        Tweet msg = tweetList.get(position);
        tweeterName.setText(msg.getTweeterName());
        tweeterNickName.setText(msg.getTweeterName());
        tweetTxt.setText(msg.getTweetText());
        //imageView.setImageURI(msg.getTweetImage()); // TODO

//        likesCount.setText(msg.getTweetLikeCount());
//        commentsCount.setText(msg.getTweetCommentCount());
//        shareCount.setText(msg.getTweetShareCount());

        return convertView;
    }
}
