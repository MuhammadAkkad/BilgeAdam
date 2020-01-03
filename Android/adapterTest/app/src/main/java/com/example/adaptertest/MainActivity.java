package com.example.adaptertest;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.ListView;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);



        String[] items = { "Parmesan","Parmesan2", "Parmesan3", "Parmesan4", "Parmesan5", "Parmesan6"};

        ArrayAdapter<String> itemsAdapter =
                new ArrayAdapter<String>(this, R.layout.activity_main, items);


        ListView listView = (ListView) findViewById(R.id.myLayout);
        listView.setAdapter(itemsAdapter);

    }
}
