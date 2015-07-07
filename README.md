# jkod

A small octal dump utility to show my skills with C#. 

- - -

## What's in this README?

1. Rationale
2. Instructions for use
3. Known Issues
4. License
5. Contact

- - -

## Rationale

If you need an idea of what a dump utility is supposed to do, please 
look [here][man od]. The basic idea for this program was to simplify 
usage of a command line utility like od, by providing not just a port, 
but a GUI.

This is a very early build. I tried my best to provide the features 
I think people actually use first.

## Instructions for use

### Opening a file

When the program opens, or when you want to look at a different file, 
click the "Open File..." button on the left hand corner of the form. 
This will present you with a standard Windows open file dialog, from 
there the user chooses the file they want to dump.

Upon selection, the program will dump the file with the selected 
options into the grey (disabled) text area.

### Options Panel

The options panel is located underneath the grey text area. The 
program currently offers 3 ways to customize your output.

1. Base

This is the number system in which the output will appear. The current 
choices are signed decimal or base 10, hexadecimal or base 16, and 
octal or base 8. The default choice is octal.

If you don't know what to pick, stick with the default, or if you like 
letters, go for hexadecimal. They are the most useful because the 
digits line up nicely with what you'd expect a nibble's value to be.

2. Column width

Column width is the number of bytes per column entry. The default 
is 2, but you can select all the way up to 8.

3. Bytes Per Line

This is the number of bytes that will be on a line. The bytes per line 
will always be a multiple of the column width. For example, choosing 
to dump a file as 4-byte hexadecimal integers with 32 bytes per line 
will result in 8 columns of output.

4. Refresh

When you want to see the same file with different output options, 
click this.

### Saving a file

Click the "Save File..." button underneath "Open File..." to keep the 
current output for later use. On clicking, the user is presented with a 
standard Windows save file dialog, from which you can choose the 
location, enter the name, and select the type of file to create.

## Known Issues

The utility will not let you look at previous dumps yet. To do this, 
open the file in a text editor.

## License

I hereby release the source code of this project into the public 
domain.

## Contact

Joshua Kittrell. <whiteflags99.at.gmail>

This email address is munged on purpose to prevent spam from 
cluttering my inbox, as futile as it may be for me to try.


[man od]: http://linuxcommand.org/man_pages/od1.html

