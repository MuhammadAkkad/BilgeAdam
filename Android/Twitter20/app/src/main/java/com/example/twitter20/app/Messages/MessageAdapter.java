package com.example.twitter20.app.Messages;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import com.example.twitter20.R;

import java.util.List;

public class MessageAdapter extends ArrayAdapter<MessageClass> {

    Context mCtx;
    int resource;
    List<MessageClass> messageClassList;
    public MessageAdapter(Context mCtx, int resource, List<MessageClass> messageClassList){
        super(mCtx, resource,messageClassList);

        this.mCtx = mCtx;
        this.resource = resource;
        this.messageClassList = messageClassList;
    }

    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        LayoutInflater inflater = LayoutInflater.from(mCtx);

        //View view = inflater.inflate(resource,null);

        convertView = LayoutInflater.from(getContext()).inflate(R.layout.fragment_message_design,parent,false);

        TextView txtName = convertView.findViewById(R.id.txt_sender_name);
        TextView txtMsg = convertView.findViewById(R.id.txt_last_msg_content);


        MessageClass msg = messageClassList.get(position);
        txtName.setText(msg.getName());
        txtMsg.setText(msg.getMessage());

        return convertView;
    }
}
