package com.example.databasetest;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Adapter;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import java.util.ArrayList;
import java.util.List;

public class CostumerAdapter extends ArrayAdapter<Data> {

    Context mCtx;
    int resource;
    List<Data> mDataList;
    public CostumerAdapter(Context mCtx, int resource, List<Data> list){
        super(mCtx, resource,list);

        this.mCtx = mCtx;
        this.resource = resource;
        this.mDataList = list;
    }

    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        //LayoutInflater inflater = LayoutInflater.from(mCtx);

        //View view = inflater.inflate(resource,null);

        convertView = LayoutInflater.from(getContext()).inflate(R.layout.list_desgin,parent,false);

        TextView txtTitle = convertView.findViewById(R.id.title);
        TextView txtSubtitle = convertView.findViewById(R.id.subtitle);

        Data d = mDataList.get(position);
        txtTitle.setText(d.title);
        txtSubtitle.setText(d.subtitle);
        return convertView;
    }
}
