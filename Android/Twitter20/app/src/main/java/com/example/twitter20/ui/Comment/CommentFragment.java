package com.example.twitter20.ui.Comment;

import android.content.Context;
import android.content.SharedPreferences;
import android.database.sqlite.SQLiteDatabase;
import android.net.Uri;
import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import com.example.twitter20.DbContract;
import com.example.twitter20.DbHelper;
import com.example.twitter20.R;

import java.util.ArrayList;
import java.util.List;


public class CommentFragment extends Fragment {
    String ID;
    DbHelper dbHelper;
    SQLiteDatabase dbRead;
    List<Comment> comments;
    ListView listView;
    int UID;

    // TODO: Rename and change types of parameters


    private OnFragmentInteractionListener mListener;

    public CommentFragment() {
        // Required empty public constructor
    }


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        final SharedPreferences pref = this.getActivity().getSharedPreferences("com.example.twitter20", Context.MODE_PRIVATE);
        UID = pref.getInt("ID", 0);
        dbHelper = new DbHelper(this.getContext());
        dbRead = dbHelper.getReadableDatabase();
        comments = new ArrayList<>();


        String[] projection = {
                DbContract.CommentEntry._ID,
                DbContract.CommentEntry.COLUMN_COMMENT
        };

        String where = DbContract.CommentEntry._ID;
        String[] whereArgs = new String[]{String.valueOf(UID)};



        return inflater.inflate(R.layout.fragment_comment, container, false);
    }



    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        if (context instanceof OnFragmentInteractionListener) {
            mListener = (OnFragmentInteractionListener) context;
        } else {
            throw new RuntimeException(context.toString()
                    + " must implement OnFragmentInteractionListener");
        }
    }

    @Override
    public void onDetach() {
        super.onDetach();
        mListener = null;
    }


    public interface OnFragmentInteractionListener {
        // TODO: Update argument type and name
        void onFragmentInteraction(Uri uri);
    }
}
