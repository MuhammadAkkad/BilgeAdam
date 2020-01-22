package com.example.twitter20.navigation.Home;

import android.content.Context;
import android.content.SharedPreferences;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import com.example.twitter20.DB.DbHelper;
import com.example.twitter20.R;

public class HomeFragment extends Fragment {


    DbHelper dbHelper;
    SQLiteDatabase dbRead;
    int UID;


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
        HomePresenter mHomePresenter = new HomePresenter(view, getContext(), UID);
        mHomePresenter.GetTweets();
    }

    public View onCreateView(@NonNull LayoutInflater inflater, final ViewGroup container, Bundle savedInstanceState) {
        View root = inflater.inflate(R.layout.fragment_home, container, false);
        return root;
    }
}