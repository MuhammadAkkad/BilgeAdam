package com.example.facebook;

import android.os.Bundle;

import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.google.android.material.snackbar.Snackbar;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Message;
import android.view.View;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.Adapter;
import android.widget.ArrayAdapter;
import android.widget.ListAdapter;
import android.widget.ListView;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    int clickCounter=0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //final ListView list = findViewById(R.id.lv_msgList);
//        ArrayList<String> arrayList = new ArrayList<>();
//        arrayList.add("JAVA");
//        arrayList.add("ANDROID");
//        arrayList.add("C Language");
//        arrayList.add("CPP Language");
//        arrayList.add("Go Language");
//        arrayList.add("AVN SYSTEMS");
//        ArrayAdapter<String> arrayAdapter = new ArrayAdapter<String>(this,
//                android.R.layout.simple_list_item_1, arrayList);
//        list.setAdapter(arrayAdapter);


        ListView listView = findViewById(R.id.lv_msgList);

        ArrayList<MsgDetails> massageList = new ArrayList<>();
        MsgDetails m1 = new MsgDetails("Atilay" , "Kanka selam napiyprsun");
        MsgDetails m2 = new MsgDetails("Orkun" , "Selamun aleykum");
        MsgDetails m3 = new MsgDetails("Simge" , "Gunaydin");
        MsgDetails m4 = new MsgDetails("Boran hoca" ,"CALIS!");
        massageList.add(m1);
        massageList.add(m2);
        massageList.add(m3);
        massageList.add(m4);


        String [] takim={"Beşiktaş","Galatasaray","Fenerbahçe","Trabzonspor","Bursaspor","Gençlerbirliği","Mersin İdman Yurdu","Torku Konyaspor","İBB",""};

        ArrayList<MsgDetails> mdList = new ArrayList<>();


        listView =(ListView)findViewById(R.id.lv_msgList);
        ArrayAdapter<MsgDetails> veriAdaptoru=new ArrayAdapter<MsgDetails>
                (this, android.R.layout.simple_list_item_1, android.R.id.text1, mdList);
        listView.setAdapter(veriAdaptoru);


//
//        ArrayAdapter<MsgDetails> arrayAdapter2 = new ArrayAdapter<MsgDetails>(this,
//                android.R.layout.simple_list_item_1, massageList);
       // listView.setAdapter(arrayAdapter2);



        FloatingActionButton fab = findViewById(R.id.fab_new_msg);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAction("Action", null).show();
            }
        });
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
