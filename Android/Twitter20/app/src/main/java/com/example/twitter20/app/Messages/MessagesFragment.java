package com.example.twitter20.app.Messages;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import androidx.annotation.Nullable;
import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;

import com.example.twitter20.R;

import java.util.ArrayList;
import java.util.List;

public class MessagesFragment extends Fragment {

    List<MessageClass> messageClasseList;
    ListView listView;
    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View root= inflater.inflate(R.layout.fragment_messages,container,false);
        return root;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        messageClasseList = new ArrayList<>();
        messageClasseList.add (new MessageClass("Muhammad" , "Hello Whatsup"));
        messageClasseList.add (new MessageClass("Ati" , "Abi sictik"));
        messageClasseList.add (new MessageClass("simge" , "otobus geldi"));
        messageClasseList.add (new MessageClass("Orkun" , "suri suri"));
        messageClasseList.add (new MessageClass("Hoca" , "isletim sistem yapin."));
        messageClasseList.add (new MessageClass("Muhammad" , "Hello Whatsup"));
        messageClasseList.add (new MessageClass("Ati" , "Abi sictik"));
        messageClasseList.add (new MessageClass("simge" , "otobus geldi"));
        messageClasseList.add (new MessageClass("Orkun" , "suri suri"));
        messageClasseList.add (new MessageClass("Hoca" , "isletim sistem yapin."));
        messageClasseList.add (new MessageClass("Muhammad" , "Hello Whatsup"));
        messageClasseList.add (new MessageClass("Ati" , "Abi sictik"));
        messageClasseList.add (new MessageClass("simge" , "otobus geldi"));
        messageClasseList.add (new MessageClass("Orkun" , "suri suri"));
        messageClasseList.add (new MessageClass("Hoca" , "isletim sistem yapin."));
        messageClasseList.add (new MessageClass("Muhammad" , "Hello Whatsup"));
        messageClasseList.add (new MessageClass("Ati" , "Abi sictik"));
        messageClasseList.add (new MessageClass("simge" , "otobus geldi"));
        messageClasseList.add (new MessageClass("Orkun" , "suri suri"));
        messageClasseList.add (new MessageClass("Hoca" , "isletim sistem yapin."));


        listView = (ListView) view.findViewById(R.id.listViewMesseges);
        // PageViewModel pgvm = ViewModelProviders.of(requireActivity()).get(PageViewModel.class);
        MessageAdapter messageAdapter = new MessageAdapter(requireActivity(), R.layout.fragment_message_design,messageClasseList);

        listView.setAdapter(messageAdapter);
    }

}