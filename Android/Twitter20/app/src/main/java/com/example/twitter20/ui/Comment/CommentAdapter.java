package com.example.twitter20.ui.Comment;
import android.content.Context;
import android.widget.ArrayAdapter;


import java.util.List;

public class CommentAdapter extends ArrayAdapter<Comment> {
    Context mCtx;
    int resource;
    static List<Comment> comments;

    public CommentAdapter(Context mCtx, int resource, List<Comment> comments) {
        super(mCtx,resource,comments);
        this.mCtx = mCtx;
        this.resource = resource;
        this.comments = comments;
    }








}
