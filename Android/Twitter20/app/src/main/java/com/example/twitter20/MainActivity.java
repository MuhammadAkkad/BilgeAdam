package com.example.twitter20;

import android.os.Bundle;

import com.example.twitter20.ui.Messages.MessagesFragment;
import com.example.twitter20.ui.home.HomeFragment;

import android.view.View;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;

import androidx.appcompat.app.AppCompatActivity;

import android.widget.Button;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    Button btnHome;
    Button btnSearch;
    Button btnNotification;
    Button btnMessage;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        btnHome = findViewById(R.id.btn_home);
        btnSearch = findViewById(R.id.btn_search);
        btnNotification = findViewById(R.id.btn_notification);
        btnMessage = findViewById(R.id.btn_messages);


        btnHome.setOnClickListener(new View.OnClickListener() {
//            FragmentManager fragmentManager = getSupportFragmentManager();
//            FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
            HomeFragment homeFragment = new HomeFragment();
            @Override
            public void onClick(View view) {
                Toast.makeText(MainActivity.this, "HOME PRESSED", Toast.LENGTH_SHORT).show();

                for (Fragment fragment : getSupportFragmentManager().getFragments()) {
                    if (fragment != null) {
                        getSupportFragmentManager().beginTransaction().detach(fragment).commit();
                    }
                }
                FragmentTransaction fragmentTransaction = GetNewTrans();
                fragmentTransaction.replace(R.id.appBarLayout, homeFragment);
                fragmentTransaction.commit();
            }
        });


        btnMessage.setOnClickListener(new View.OnClickListener() {
            //FragmentManager fragmentManager = getSupportFragmentManager();
            //FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
            MessagesFragment messageFragment = new MessagesFragment();
            @Override
            public void onClick(View view) {
                Toast.makeText(MainActivity.this, "MESSAGE PRESSED", Toast.LENGTH_SHORT).show();

                for (Fragment fragment : getSupportFragmentManager().getFragments()) {
                    if (fragment != null) {
                        getSupportFragmentManager().beginTransaction().detach(fragment).commit();
                    }
                }
                FragmentTransaction fragmentTransaction = GetNewTrans();
                fragmentTransaction.replace(R.id.appBarLayout, messageFragment);
                fragmentTransaction.commit();
            }
        });


    }

    FragmentTransaction GetNewTrans(){
        FragmentManager fragmentManager = getSupportFragmentManager();
        FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
        return fragmentTransaction;
    }
}
