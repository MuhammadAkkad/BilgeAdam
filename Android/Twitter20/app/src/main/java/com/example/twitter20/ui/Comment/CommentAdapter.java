package com.example.twitter20.ui.Comment;

import android.content.Context;
import android.content.SharedPreferences;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import com.example.twitter20.R;

import java.util.List;

public class CommentAdapter extends ArrayAdapter<Comment> {

    TextView replyer_name;
    TextView nickname;
    TextView replying_to;
    TextView comment;

    static List<Comment> comments;
    int UID;
    Context mCtx;
    int resource;

    public CommentAdapter(Context mCtx, int resource, List<Comment> comments) {
        super(mCtx, resource, comments);
        this.mCtx = mCtx;
        this.resource = resource;
        this.comments = comments;
    }

    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        final SharedPreferences pref = getContext().getSharedPreferences("com.example.twitter20", Context.MODE_PRIVATE);
        UID = pref.getInt("ID", -1);
        convertView = LayoutInflater.from(getContext()).inflate(R.layout.fragment_comment_list_design, parent, false);

        replyer_name = convertView.findViewById(R.id.replyer_name);
        nickname = convertView.findViewById(R.id.replyer_nickname);
        replying_to = convertView.findViewById(R.id.replying_to);
        comment = convertView.findViewById(R.id.reply_text_content);

        Comment c = comments.get(position);
        comment.setText(c.Comment);



        return convertView;

    }
}
