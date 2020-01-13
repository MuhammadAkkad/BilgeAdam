package com.example.twitter20;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.view.GravityCompat;
import androidx.drawerlayout.widget.DrawerLayout;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;

import com.example.twitter20.ui.Messages.MessagesFragment;
import com.example.twitter20.ui.Notification.NotificationFragment;
import com.example.twitter20.ui.Search.SeachFragment;
import com.example.twitter20.ui.Tweet.HomeFragment;
import com.example.twitter20.ui.Tweet.NewTweetActivity;

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
            HomeFragment homeFragment = new HomeFragment();
            @Override
            public void onClick(View view) {
                Toast.makeText(MainActivity.this, "HOME PRESSED", Toast.LENGTH_SHORT).show();

                for (Fragment fragment : getSupportFragmentManager().getFragments()) {
                    if (fragment != null) {
                        getSupportFragmentManager().beginTransaction().remove(fragment).commit();
                    }
                }
                FragmentTransaction fragmentTransaction = GetNewTrans();
                fragmentTransaction.add(R.id.appBarLayout, homeFragment);
                fragmentTransaction.commit();
            }
        });
        btnMessage.setOnClickListener(new View.OnClickListener() {
            MessagesFragment messageFragment = new MessagesFragment();
            @Override
            public void onClick(View view) {
                Toast.makeText(MainActivity.this, "MESSAGE PRESSED", Toast.LENGTH_SHORT).show();

                for (Fragment fragment : getSupportFragmentManager().getFragments()) {
                    if (fragment != null) {
                        getSupportFragmentManager().beginTransaction().remove(fragment).commit();
                    }
                }
                FragmentTransaction fragmentTransaction = GetNewTrans();
                fragmentTransaction.add(R.id.appBarLayout, messageFragment);
                fragmentTransaction.commit();
            }
        });
        btnSearch.setOnClickListener(new View.OnClickListener() {
            SeachFragment mSearchFragment = new SeachFragment();
            @Override
            public void onClick(View view) {
                Toast.makeText(MainActivity.this, "SEARCH PRESSED", Toast.LENGTH_SHORT).show();

                for (Fragment fragment : getSupportFragmentManager().getFragments()) {
                    if (fragment != null) {
                        getSupportFragmentManager().beginTransaction().remove(fragment).commit();
                    }
                }
                FragmentTransaction fragmentTransaction = GetNewTrans();
                fragmentTransaction.add(R.id.appBarLayout, mSearchFragment);
                fragmentTransaction.commit();
            }
        });
        btnNotification.setOnClickListener(new View.OnClickListener() {
            NotificationFragment mNotificationFragment = new NotificationFragment();
            @Override
            public void onClick(View view) {
                Toast.makeText(MainActivity.this, "NOTI PRESSED", Toast.LENGTH_SHORT).show();

                for (Fragment fragment : getSupportFragmentManager().getFragments()) {
                    if (fragment != null) {
                        getSupportFragmentManager().beginTransaction().remove(fragment).commit();
                    }
                }
                FragmentTransaction fragmentTransaction = GetNewTrans();
                fragmentTransaction.add(R.id.appBarLayout, mNotificationFragment);
                fragmentTransaction.commit();
            }
        });

    }
    // renews transaction instance to avoid crash!
    FragmentTransaction GetNewTrans(){
        FragmentManager fragmentManager = getSupportFragmentManager();
        FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
        return fragmentTransaction;
    }
    // new tweet button onClick action
    public void NewTweetButton(View view) {
        Intent i = new Intent(getBaseContext(), NewTweetActivity.class);
        startActivity(i);
    }
    // Opens navigation drawer
    public void OpenDrawer(View view) {
        DrawerLayout drawerLayout = (DrawerLayout) findViewById(R.id.drawer_layout);
        drawerLayout.openDrawer(GravityCompat.START);
    }
}
