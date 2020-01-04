package com.example.twitter20.ui.home;

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

    List<Tweet> tweetList;
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

        tweetList = new ArrayList<>(); // TODO add fake tweets below
        tweetList.add (new Tweet("Muhammad", "AkkadNick", new Date(1900, 1, 1) ,"this is my very powerful tweet because i can and why not to tweet everyday about shit?"));
        tweetList.add (new Tweet("Muhammad", "AkkadNick", new Date(1900, 1, 1) ,"this is my very powerful tweet because i can and why not to tweet everyday about shit?"));
        tweetList.add (new Tweet("Muhammad", "AkkadNick", new Date(1900, 1, 1) ,"this is my very powerful tweet because i can and why not to tweet everyday about shit?"));
        tweetList.add (new Tweet("Muhammad", "AkkadNick", new Date(1900, 1, 1) ,"this is my very powerful tweet because i can and why not to tweet everyday about shit?"));
        tweetList.add (new Tweet("Muhammad", "AkkadNick", new Date(1900, 1, 1) ,"this is my very powerful tweet because i can and why not to tweet everyday about shit?"));
        tweetList.add (new Tweet("Muhammad", "AkkadNick", new Date(1900, 1, 1) ,"this is my very powerful tweet because i can and why not to tweet everyday about shit?"));
        tweetList.add (new Tweet("Muhammad", "AkkadNick", new Date(1900, 1, 1) ,"this is my very powerful tweet because i can and why not to tweet everyday about shit?"));
        tweetList.add (new Tweet("Muhammad", "AkkadNick", new Date(1900, 1, 1) ,"this is my very powerful tweet because i can and why not to tweet everyday about shit?"));
        tweetList.add (new Tweet("Muhammad", "AkkadNick", new Date(1900, 1, 1) ,"this is my very powerful tweet because i can and why not to tweet everyday about shit?"));
        tweetList.add (new Tweet("Muhammad", "AkkadNick", new Date(1900, 1, 1) ,"this is my very powerful tweet because i can and why not to tweet everyday about shit?"));
        tweetList.add (new Tweet("Muhammad", "AkkadNick", new Date(1900, 1, 1) ,"this is my very powerful tweet because i can and why not to tweet everyday about shit?"));


        listView = (ListView) view.findViewById(R.id.TweetsList); // TODO fix view

        HomeAdapter HomeAdapter = new HomeAdapter(getActivity(), R.layout.fragment_home_design,tweetList);

        listView.setAdapter(HomeAdapter);
    }

    public View onCreateView(@NonNull LayoutInflater inflater,
                             final ViewGroup container, Bundle savedInstanceState) {
        homeViewModel =
                ViewModelProviders.of(this).get(HomeViewModel.class);
        View root = inflater.inflate(R.layout.fragment_home, container, false);
//        final TextView textView = root.findViewById(R.id.text_home);
//        homeViewModel.getText().observe(this, new Observer<String>() {
//            @Override
//            public void onChanged(@Nullable String s) {
//                textView.setText(s);
//            }
//        });
        return root;
    }
}