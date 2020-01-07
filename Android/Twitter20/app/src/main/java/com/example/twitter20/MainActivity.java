package com.example.twitter20;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;

import com.example.twitter20.ui.Messages.MessagesFragment;
import com.example.twitter20.ui.home.HomeFragment;
import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.google.android.material.snackbar.Snackbar;

import android.view.View;

import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.ui.AppBarConfiguration;
import androidx.navigation.ui.NavigationUI;

import com.google.android.material.navigation.NavigationView;
import com.google.android.material.tabs.TabLayout;

import androidx.drawerlayout.widget.DrawerLayout;

import androidx.appcompat.app.AppCompatActivity;
import androidx.viewpager.widget.ViewPager;

import android.view.Menu;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.Toolbar;

public class MainActivity extends AppCompatActivity {

    Button btnHome;
    Button btnSearch;
    Button btnNotification;
    Button btnMessage;
    Button btnPP;
    FloatingActionButton twitButton;
    TabLayout tabLayout;
    Toolbar toolbar;
    ViewPager viewPager;
    Context context = this;
    private AppBarConfiguration mAppBarConfiguration;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        btnHome = findViewById(R.id.btn_home);
        btnSearch = findViewById(R.id.btn_search);


        btnNotification = findViewById(R.id.btn_notification);
        btnMessage = findViewById(R.id.btn_messages);


        HomeFragment homeFragment = new HomeFragment();
        FragmentManager fragmentManager = getSupportFragmentManager();
        FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
        fragmentTransaction.replace(R.id.drawer_layout,homeFragment,"home");
        fragmentTransaction.commit();




        btnHome.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                HomeFragment homeFragment = new HomeFragment();
                FragmentManager fragmentManager2 = getSupportFragmentManager();
                FragmentTransaction fragmentTransaction = fragmentManager2.beginTransaction();
                fragmentTransaction.replace(R.id.drawer_layout,homeFragment,"home");
                fragmentTransaction.commit();

            }
        });



        btnMessage.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                MessagesFragment messageFragment = new MessagesFragment();
                FragmentManager fragmentManager = getSupportFragmentManager();
                FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
                fragmentTransaction.replace(R.id.drawer_layout,messageFragment,"message");
                fragmentTransaction.commit();
            }
        });
//
//        btnNotification.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View view) {
//                NotificationFragment homeFragment = new NotificationFragment();
//                FragmentManager fragmentManager = getSupportFragmentManager();
//                FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
//                fragmentTransaction.replace(R.id.mainConstraint,homeFragment,"notification");
//                fragmentTransaction.commit();
//            }
//        });

//        btnSearch.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View view) {
//                Toast.makeText(getApplicationContext(),"tıklandı search",Toast.LENGTH_SHORT).show();
//                SearchFragment searchFragment = new SearchFragment();
//
//                FragmentManager fragmentManager = getSupportFragmentManager();
//                FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
//                fragmentTransaction.replace(R.id.mainConstraint,searchFragment,"search");
//                fragmentTransaction.commit();
//            }
//        });

    }
}
